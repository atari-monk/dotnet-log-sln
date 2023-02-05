--Run only selected !!
--get logs that have duplicated task
SELECT [Id]
      ,[TaskId]
      ,[PlaceId]
      ,[Start]
      ,[End]
      ,[TimeTicks]
      ,[Description]
  FROM [LogData].[dbo].[Log]
  WHERE [TaskId] IN (98, 108)

--remove duplicates
--first
UPDATE [dbo].[Log]
	SET [TaskId] = 98
 WHERE [Id] = 6235
--more
UPDATE [dbo].[Log]
	SET [TaskId] = 98
 WHERE [Id] IN (9587, 9591)

--delete duplicate task
 DELETE FROM [dbo].[Task]
      WHERE [Id] = 108

--Show there is no duplicate no more
SELECT [Id]
      ,[CategoryId]
      ,[Name]
      ,[Description]
  FROM [LogData].[dbo].[Task]
  WHERE [CategoryId] = 12 AND [Name] LIKE '%scrip%'