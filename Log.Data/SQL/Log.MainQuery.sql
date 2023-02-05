
SELECT TOP (1000) [Id]
      ,[TaskId]
      ,[PlaceId]
      ,[Start]
      ,[End]
      ,[TimeTicks]
      ,[Description]
  FROM [LogData].[dbo].[Log]
  WHERE 
  [Start] BETWEEN {ts '2022-02-19 00:00:00'} AND {ts '2022-02-19 23:59:59'}
  OR 
  [Start] IS NULL