IF EXISTS(SELECT *
          FROM INFORMATION_SCHEMA.TABLES
          WHERE TABLE_NAME = 'Answers'
            AND TABLE_SCHEMA = 'dbo')
    DROP TABLE dbo.Answers;

IF EXISTS(SELECT *
          FROM INFORMATION_SCHEMA.TABLES
          WHERE TABLE_NAME = 'QuestionLevel'
            AND TABLE_SCHEMA = 'dbo')
    DROP TABLE dbo.QuestionLevel;

IF EXISTS(SELECT *
          FROM INFORMATION_SCHEMA.TABLES
          WHERE TABLE_NAME = 'Questions'
            AND TABLE_SCHEMA = 'dbo')
    DROP TABLE dbo.Questions;


CREATE TABLE [dbo].[QuestionLevel]
(
    [LevelId]      [int]   NOT NULL,
    [ValueOfLevel] [money] NOT NULL,
    CONSTRAINT [PK_QuestionLevel] PRIMARY KEY CLUSTERED
        (
         [LevelId] ASC
            ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Questions]
(
    [QuestionId]        [int]        NOT NULL,
    [QuestionText]      [nchar](100) NOT NULL,
    [QuestionOfLevelId] [int]        NOT NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED
        (
         [QuestionId] ASC
            ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Answers]
(
    [AnswerId]        [int]       NOT NULL,
    [AnswerText]      [nchar](50) NOT NULL,
    [AnswerIsCorrect] [bit]       NOT NULL,
    [QuestionId]      [int]       NOT NULL,
    CONSTRAINT [AnswerId] PRIMARY KEY CLUSTERED
        (
         [AnswerId] ASC
            ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

insert into dbo.QuestionLevel(LevelId, ValueOfLevel)
values (1, 100),
       (2, 200),
       (3, 300),
       (4, 500),
       (5, 1000),
       (6, 2000),
       (7, 4000),
       (8, 8000),
       (9, 16000),
       (10, 32000),
       (11, 64000),
       (12, 125000),
       (13, 250000),
       (14, 500000),
       (15, 1000000)

insert into dbo.Questions(QuestionId, QuestionText, QuestionOfLevelId)
values (1, 'What is another name for the camelopard?', 1),
       (2, 'A Third-year college student is usually called a what?', 2),
       (3, 'According to the Bible, Moses and Aaron had a sister named what?', 3),
       (4, 'According to the Mother Goose nursery rhyme, which child is full of woe?', 4),
       (5, 'For a man and woman on a date, "dutch treat" means what?', 5),
       (6, 'How is 4:00 pm expressed in military time?', 6),
       (7, 'How much does Peanuts character Lucy charge for her psychiatric advice?', 7),
       (8, 'In what war did Joan of Arc fight?', 8),
       (9, 'Modern computer microchips are primarily composed of what element?', 9),
       (10, 'On average, what length of time passes between high tides?', 10),
       (11, 'On "TVs Seinfeld" what type of doctor did Mr. Costanza go to when he sat on "fusilli Jerry"?', 11),
       (12, 'To create a tapestry, one must traditionally engage in what activity?', 12),
       (13, 'What article of clothing best describes a "pashmina"?', 13),
       (14, 'What condition is caused by malfunctioning sebaceous glands?', 14),
       (15, 'When Battle of Karansebes happned?', 15);

insert into dbo.Answers(AnswerId, AnswerText, AnswerIsCorrect, QuestionId)
values (1, 'circus', 0, 1),
       (2, 'giraffe', 0, 1),
       (3, 'cantaloupe', 1, 1),
       (4, 'oasis', 0, 1),
       (5, 'sophomore', 0, 2),
       (6, 'senior', 0, 2),
       (7, 'freshman', 0, 2),
       (8, 'junior', 1, 2),
       (9, 'Jochebed', 0, 3),
       (10, 'Ruth', 0, 3),
       (11, 'Leah', 0, 3),
       (12, 'Miriam', 1, 3),
       (13, 'Mondays child', 0, 4),
       (14, 'Wednesdays child', 1, 4),
       (15, 'Thursdays child', 0, 4),
       (16, 'Saturdays child', 0, 4),
       (17, 'the man pays', 0, 5),
       (18, 'the woman pays', 0, 5),
       (19, 'the Dutch pay', 0, 5),
       (20, 'each pays their own way ', 1, 5),
       (21, '1600', 1, 6),
       (22, '004', 0, 6),
       (23, '0400', 0, 6),
       (24, '00', 0, 6),
       (25, '5 cents', 1, 7),
       (26, '10 cents', 0, 7),
       (27, '75 cents', 0, 7),
       (28, '$125', 0, 7),
       (29, 'Hundred Years War', 1, 8),
       (30, 'Franco-Prussian War', 0, 8),
       (31, 'French Revolution', 0, 8),
       (32, 'French and Indian War', 0, 8),
       (33, 'Sodium', 0, 9),
       (34, 'Silicon', 1, 9),
       (35, 'Aluminum', 0, 9),
       (36, 'Silver', 0, 9),
       (37, '3 hours, 25 minutes', 0, 10),
       (38, '6 hours, 25 minutes', 0, 10),
       (39, '12 hours, 25 minutes', 1, 10),
       (40, '24 hours, 25 minutes', 0, 10),
       (41, 'ophthalmologist', 0, 11),
       (42, 'cardiologist', 0, 11),
       (43, 'neurologist', 0, 11),
       (44, 'proctologist', 1, 11),
       (45, 'weaving', 1, 12),
       (46, 'sculpting', 0, 12),
       (47, 'baking', 0, 12),
       (48, 'singing', 0, 12),
       (49, 'shoes', 0, 13),
       (50, 'pants', 0, 13),
       (51, 'scarf', 1, 13),
       (52, 'underwear', 1, 13),
       (53, 'bad breath', 0, 14),
       (54, 'acne', 1, 14),
       (55, 'shingles', 0, 14),
       (56, 'carpal tunnel syndrome', 0, 14),
       (57, '1371', 0, 15),
       (58, '1867', 0, 15),
       (59, '1712', 0, 15),
       (60, '1788', 1, 15)

    

    