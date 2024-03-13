using AutoMapper;
using Iqra_Quran_Center.Application.Abstractions.IRepository;
using Iqra_Quran_Center.Application.Abstractions.IServices;
using Iqra_Quran_Center.Application.BaseResponse;
using Iqra_Quran_Center.Application.RRModels;
using Iqra_Quran_Center.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqra_Quran_Center.Application.Services
{
    public class ExamsService
        (IExamsRepository repository,
        IMapper mapper,
        IContextService contextService,
        IQuestionsRepository questionsRepository,
        IAnswersRepository answersRepository,
        IResultsRepository resultsRepository
        ) : IExamsService
    {
        public async Task<APIResponse<int>> AddExam(ExamRequest model)
        {
            var exam = mapper.Map<Exam>(model);

            var res = await repository.AddAsync(exam);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Exam has been Created Successfully");

            return APIResponse<int>.ErrorResponse();
        }



        public async Task<APIResponse<int>> AttendExam(ExamAttendingRequest model)
        {
            var exam = await repository.GetByIdAsync(model.ExamId);

            if (exam is null)
                return APIResponse<int>.ErrorResponse("No Such Exam found");

            if (exam.ExamStatus != Domain.Enums.ExamStatus.Conducted)
                return APIResponse<int>.ErrorResponse("Exam has not been started yet");

            if (exam.ExamDateTime > DateTime.Now)
                return APIResponse<int>.ErrorResponse($"Exam will start on {exam.ExamDateTime}");

            if (exam.ExamEndDateTime < DateTime.Now)
                return APIResponse<int>.ErrorResponse($"Exam has been ended");

            var studentId = contextService.GetId();

            var isPaperSubmitted = await resultsRepository.IsExistsAsync(_ => _.StudentId == studentId && model.ExamId == _.ExamId);

            if (isPaperSubmitted)
                return APIResponse<int>.ErrorResponse("Paper Already Submitted");

            var questions = await QuestionWithAnswers(model.ExamId);
            var qns = questions?.Result?.QuestionAnswers;

            var correctAnswers = 0;

            List<Guid> submittedQns = new List<Guid>();

            foreach (var ans in model.Answers)
            {
                if (!submittedQns.Contains(ans.QuestionId))
                {
                    var questionAnswer = qns?.FirstOrDefault(_ => _.QuestionId == ans.QuestionId);

                    var answer = questionAnswer?.Answers.FirstOrDefault(_ => _.IsCorrect);

                    if (ans.AnswerId == answer?.Id)
                        correctAnswers += exam is not null ? exam.TotalMarks / exam.TotalNoOfQuestions : 0;

                    submittedQns.Add(ans.QuestionId);
                }

            }

            var result = new Result
            {
                ExamId = model.ExamId,
                MarksObtained = correctAnswers,
                Attempts = model.Answers.Count(),
                StudentId = studentId,
                HasQualified = correctAnswers >= exam?.PassingMarks
            };

            var res = await resultsRepository.AddAsync(result);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Paper Submitted Successfully");

            return APIResponse<int>.ErrorResponse();
        }



        public async Task<APIResponse<QuestionWithAnswersResponse>> QuestionWithAnswers(Guid examId)
        {
            var questions = await questionsRepository.FilterAsync(_ => _.ExamId == examId);

            var response = new QuestionWithAnswersResponse
            {
                Examid = examId,
            };

            response.QuestionAnswers = new List<QuestionWithAnswer>();

            foreach (QuestionPaper qn in questions)
            {
                var answers = await answersRepository.ViewAnswersByQuestionId(qn.Id);
                var questionAnswer = new QuestionWithAnswer
                {
                    QuestionId = qn.Id,
                    Answers = answers
                };
                response.QuestionAnswers.Add(questionAnswer);
            }

            return APIResponse<QuestionWithAnswersResponse>.SuccessResponse(response);
        }

        public async Task<APIResponse<int>> UpdateChangeExam(ExamStatusRequest model)
        {
            var exam = await repository.GetByIdAsync(model.Id);

            if (exam is null)
                return APIResponse<int>.ErrorResponse("No Such Exam found");

            if (model.ExamDateTime < DateTime.Now)
                return APIResponse<int>.ErrorResponse("Please Select exam date greater than todays date");


            exam.ExamStatus = model.ExamStatus;
            exam.ExamDateTime = model.ExamDateTime;
            exam.PassingMarks = model.PassingMarks;
            exam.TotalMarks = model.TotalMarks;
            exam.PassingMarks = model.PassingMarks;
            exam.Title = model.Title;
            exam.TotalNoOfQuestions = model.TotalNoOfQuestions;

            var res = await repository.UpdateAsync(exam);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(res, "Exam has been Updated Successfully");

            return APIResponse<int>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<ExamResponse>>> ViewExams()
        {
            var exams = await repository.ViewExams();

            return APIResponse<IEnumerable<ExamResponse>>.SuccessResponse(exams);
        }

        public async Task<APIResponse<IEnumerable<ExamResponse>>> ViewExamsByGroupId(Guid? groupId)
        {
            var GROUP_ID = Guid.Parse(Convert.ToString(groupId is null ? contextService.GetGroupId() : groupId)!);

            var exams = await repository.ViewExamsByGroupId(GROUP_ID);

            return APIResponse<IEnumerable<ExamResponse>>.SuccessResponse(exams);
        }

    }
}
