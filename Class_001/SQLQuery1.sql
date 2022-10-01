
CREATE TABLE student
(
	stuId VARCHAR(10) PRIMARY KEY,
	stuName VARCHAR(50) NOT NULL,
	stuAddress VARCHAR(200) NOT NULL
)
INSERT INTO student VALUES
('s001','Zinat Ara','Pabna'),
('s002','Nahid','Tangail'),
('s003','Babu','Dhaka')
GO
SELECT * FROM student
GO
