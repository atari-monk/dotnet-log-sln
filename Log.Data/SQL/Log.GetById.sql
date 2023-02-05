/****** Script for SelectTopNRows command from SSMS  ******/
SELECT  [Id]
      ,[TaskId]
      ,[PlaceId]
      ,[Start]
      ,[End]
      ,[TimeTicks]
      ,[Description]
  FROM [LogData].[dbo].[Log] WHERE [ID] = '10701'