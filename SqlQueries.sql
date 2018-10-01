
--1. Query to get data in following format: Date, Count of new Pastes for the date
--Result: Count of Pastes created on specific date
SELECT CreateDate as [Date], COUNT(*) as [Count]
FROM dbo.Paste
GROUP BY CreateDate


--2. Query to ge data in following format: Date, The latest Paste which was requested at specific date
--Result: Paste which was requested last by the dates of creation
;WITH pastes AS
(
  SELECT CreateDate as [Date], Content, Identifier,  RowNum=ROW_NUMBER() OVER (PARTITION BY CreateDate ORDER BY AccessDate DESC)
  FROM dbo.Paste
)
SELECT [Date],Content,Identifier
FROM pastes
WHERE RowNum=1
