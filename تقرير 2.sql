USE [Fin]
GO

/****** Object:  StoredProcedure [dbo].[SpGetReport2]    Script Date: 23/05/2023 15:04:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpGetReport2]
	-- Add the parameters for the stored procedure here
	 @StartDate date,
	 @EndDate date ,
	 @MainPaycheckNumber nvarchar(50)  ,
     @CurrenName nvarchar(50) ,
	 @FundName nvarchar(50) ,
	 @MainPaycheckStatus int = 5
	 
AS
BEGIN
	IF(@MainPaycheckNumber != 'null' or @CurrenName != 'null'or  @FundName != 'null' or @MainPaycheckStatus != 5)
	BEGIN
   SELECT  dbo.Main_PayCheck.MainPaycheckNumber, dbo.Main_PayCheck.MainPaycheckAmount_RLY,
     dbo.Currencies.CurrenName, dbo.Funds.FundName,dbo.Currencies.CurreType , dbo.Main_PayCheck.MainPaycheckDate


FROM     dbo.Main_PayCheck INNER JOIN

                  dbo.Detailed_PayCheck ON dbo.Main_PayCheck.MainPaycheckNumber = dbo.Detailed_PayCheck.main_paycheck INNER JOIN
                  dbo.Funds ON dbo.Main_PayCheck.funds = dbo.Funds.Funds_Id INNER JOIN
                  dbo.Currencies ON dbo.Main_PayCheck.currencies = dbo.Currencies.Currencies_Id INNER JOIN
                  dbo.Fiscal_Year ON dbo.Main_PayCheck.fiscal_year = dbo.Fiscal_Year.Fiscal_Year_Id

				   where dbo.Main_PayCheck.MainPaycheckDate between @StartDate and @EndDate and
				 dbo.Main_PayCheck.funds = @FundName
				  or  dbo.Main_PayCheck.currencies = @CurrenName  or
				  dbo.Main_PayCheck.MainPaycheckNumber = @MainPaycheckNumber or
				 dbo.Main_PayCheck.MainPaycheckStatus = @MainPaycheckStatus 
				  

				  Group By dbo.Main_PayCheck.MainPaycheckNumber, dbo.Main_PayCheck.MainPaycheckAmount_RLY,
                  dbo.Currencies.CurrenName, dbo.Funds.FundName, dbo.Currencies.CurreType , dbo.Main_PayCheck.MainPaycheckDate

	END
	ELSE
	BEGIN
	SELECT  dbo.Main_PayCheck.MainPaycheckNumber, dbo.Main_PayCheck.MainPaycheckAmount_RLY,
     dbo.Currencies.CurrenName, dbo.Funds.FundName, dbo.Currencies.CurreType ,dbo.Main_PayCheck.MainPaycheckDate


FROM     dbo.Main_PayCheck INNER JOIN

                  dbo.Detailed_PayCheck ON dbo.Main_PayCheck.MainPaycheckNumber = dbo.Detailed_PayCheck.main_paycheck INNER JOIN
                  dbo.Funds ON dbo.Main_PayCheck.funds = dbo.Funds.Funds_Id INNER JOIN
                  dbo.Currencies ON dbo.Main_PayCheck.currencies = dbo.Currencies.Currencies_Id INNER JOIN
                  dbo.Fiscal_Year ON dbo.Main_PayCheck.fiscal_year = dbo.Fiscal_Year.Fiscal_Year_Id

				   where dbo.Main_PayCheck.MainPaycheckDate between @StartDate and @EndDate 
				  
				  

				  Group By dbo.Main_PayCheck.MainPaycheckNumber, dbo.Main_PayCheck.MainPaycheckAmount_RLY,
                  dbo.Currencies.CurrenName, dbo.Funds.FundName, dbo.Currencies.CurreType , dbo.Main_PayCheck.MainPaycheckDate
	END
END
GO


