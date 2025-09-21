create database ZelisTrainingDB

use ZelisTrainingDB


--- creating Employee Table 
CREATE TABLE Employee (
    EmpId INT PRIMARY KEY,
    EmpName VARCHAR(100),
    Designation VARCHAR(100),
    Email VARCHAR(100),
    Phone VARCHAR(20)
);

INSERT INTO Employee (EmpId, EmpName, Designation, Email, Phone) VALUES
(1, 'Aliya', 'Software Engineer', 'aliya@zelis.com', '9381150433'),
(2, 'Babu', 'Senior Developer', 'babu@zelis.com', '9786546721'),
(3, 'Carol', 'QA Analyst', 'carol@zelis.com', '9082314765'),
(4, 'David', 'Project Manager', 'david@zelis.com', '9432567189'),
(5, 'Eva', 'Business Analyst', 'eva@zelis.com', '9871243765');


CREATE TABLE Technology (
    TechnologyId INT PRIMARY KEY,
    TechnologyName VARCHAR(100),
    Level CHAR(1) CHECK (Level IN ('B', 'I', 'A')), -- B: Basic, I: Intermediate, A: Advanced
    Duration INT -- Duration in days
);

INSERT INTO Technology (TechnologyId, TechnologyName, Level, Duration) VALUES
(101, 'SQL Server', 'B', 10),
(102, 'Python', 'I', 15),
(103, 'Azure Cloud', 'A', 20),
(104, 'ReactJS', 'I', 12),
(105, 'Docker', 'B', 8);


CREATE TABLE Trainer (
    TrainerId INT PRIMARY KEY,
    TrainerName VARCHAR(100),
    Type CHAR CHECK (Type IN ('I', 'E')), -- I: Internal, E: External
    Email VARCHAR(100),
    Phone VARCHAR(20)
);


INSERT INTO Trainer (TrainerId, TrainerName, Type, Email, Phone) VALUES
(201, 'John', 'I', 'john@zelis.com', '8381150433'),
(202, 'Megan', 'E', 'megan@zelis.com', '8786546721'),
(203, 'Kyle', 'I', 'kyle@zelis.com', '8082314765'),
(204, 'Nina', 'E', 'nina@zelis.com', '8432567189'),
(205, 'Sam', 'I', 'sam@zelis.com', '8871243765');


CREATE TABLE Training (
    TrainingId INT PRIMARY KEY,
    TrainerId INT,
    TechnologyId INT,
    StartDate DATE,
    EndDate DATE,
    CONSTRAINT FK_Training_Trainer FOREIGN KEY (TrainerId) REFERENCES Trainer(TrainerId),
    CONSTRAINT FK_Training_Technology FOREIGN KEY (TechnologyId) REFERENCES Technology(TechnologyId)
);


INSERT INTO Training (TrainingId, TrainerId, TechnologyId, StartDate, EndDate) VALUES
(301, 201, 101, '2025-10-01', '2025-10-10'), 
(302, 202, 102, '2025-10-05', '2025-10-20'), 
(303, 203, 103, '2025-11-01', '2025-11-20'),
(304, 204, 104, '2025-11-15', '2025-11-27'),
(305, 205, 105, '2025-12-01', '2025-12-09');


CREATE TABLE Trainee (
    TrainingId INT,
    EmpId INT,
    Status CHAR(1) CHECK (Status IN ('C', 'N')), -- C: Completed, N: Not completed
    CONSTRAINT PK_Trainee PRIMARY KEY (TrainingId, EmpId),
    CONSTRAINT FK_Trainee_Training FOREIGN KEY (TrainingId) REFERENCES Training(TrainingId),
    CONSTRAINT FK_Trainee_Employee FOREIGN KEY (EmpId) REFERENCES Employee(EmpId)
);

INSERT INTO Trainee (TrainingId, EmpId, Status) VALUES
(301, 1, 'C'), 
(301, 2, 'N'), 
(302, 3, 'C'), 
(303, 4, 'N'), 
(304, 5, 'C');