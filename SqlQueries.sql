
--1. Запрос для получения выборки вида: Дата (сутки), Колличество новых Paste за сутки
--Результат: Количество Paste созданных в определённую дату
SELECT CreateDate as [Date], COUNT(*) as [Count]
FROM dbo.Paste
GROUP BY CreateDate


--2. Запрос для получения выборки вида: Дата (сутки), Самый последний Paste к которому был доступ в сутках
--Результат: Paste к которым обращались позже всех по дням их созднания
;WITH pastes AS
(
  SELECT CreateDate as [Date], Content, Identifier,  RowNum=ROW_NUMBER() OVER (PARTITION BY CreateDate ORDER BY AccessDate DESC)
  FROM dbo.Paste
)
SELECT [Date],Content,Identifier
FROM pastes
WHERE RowNum=1

--3. Запрос для получения ближайшей даты (суток) относительно указанного параметра X, в которую не было ни одного доступа к любому Paste
DECLARE @X as DATE
SET @X = '2018-08-08'

SELECT * FROM  dbo.Paste WHERE AccessDate
