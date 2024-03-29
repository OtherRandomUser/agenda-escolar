using System;
using Diary.Domain.Base;

namespace Diary.Domain
{
    public class Assignment : Entity
    {
        public Guid ClassId { get; private set; }
        public Class Class { get; private set; }
        public DateTime DueAt { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public float MaxGrade { get; private set; }
        public string NotificationJobId { get; private set; }

        public Assignment()
        {
        }

        public Assignment(Class @class, DateTime dueAt, string title, string description, float maxGrade)
        {
            ClassId = @class?.Id ?? throw new ArgumentNullException(nameof(@class));
            Class = @class;
            SetDueAt(dueAt);
            SetTitle(title);
            SetDescription(description);
            SetMaxGrade(maxGrade);
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));
        
            Title = title;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentNullException(nameof(description));

            Description = description;
        }

        public void SetMaxGrade(float maxGrade)
        {
            if (maxGrade < 0)
                throw new ArgumentOutOfRangeException(nameof(maxGrade));

            MaxGrade = maxGrade;
        }

        public void SetDueAt(DateTime dueAt)
        {
            if (dueAt < DateTime.UtcNow)
                throw new ArgumentOutOfRangeException(nameof(dueAt));

            DueAt = dueAt;
        }

        public void SetNotificationEventId(string jobId)
        {
            if (string.IsNullOrWhiteSpace(jobId))
                throw new ArgumentNullException(nameof(jobId));

            NotificationJobId = jobId;
        }
    }
}