public record EnrollStudentDto(int StudentId, int CourseId);

public record EnrollmentDto(int StudentId, string StudentName,
                            int CourseId, string CourseTitle,
                            DateTime EnrolledAt);