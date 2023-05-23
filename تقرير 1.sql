USE [Fin]
GO

/****** Object:  StoredProcedure [dbo].[SpGetReport]    Script Date: 23/05/2023 15:03:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SpGetReport]
	-- Add the parameters for the stored procedure here
	 @StartDate date,
	 @EndDate date ,
	 @MainExpensVoucherNumber nvarchar(50)  ,
     @CurrenName nvarchar(50) ,
	 @FundName nvarchar(50) ,
	 @MainExpensVoucherStatus int = 5
	 --@IsDelete int
AS
BEGIN
	IF(@MainExpensVoucherNumber != 'null' or @CurrenName != 'null'or  @FundName != 'null' or @MainExpensVoucherStatus != 5)
	BEGIN
    SELECT  dbo.Main_Expens_Voucher.Main_ExpensVoucher_Number, dbo.Main_Expens_Voucher.MainExpensVoucherAmount_RLY, dbo.Currencies.CurrenName, 
                  dbo.Currencies.CurreType, dbo.Funds.FundName, dbo.Main_Expens_Voucher.MainExpensVoucherDate

    FROM     dbo.Main_Expens_Voucher INNER JOIN

                  dbo.Detailed_Expens_Voucher ON dbo.Main_Expens_Voucher.Main_ExpensVoucher_Number = dbo.Detailed_Expens_Voucher.main_expens_voucher_number INNER JOIN
                  dbo.Currencies ON dbo.Main_Expens_Voucher.currencies = dbo.Currencies.Currencies_Id INNER JOIN
                  dbo.Funds ON dbo.Main_Expens_Voucher.funds = dbo.Funds.Funds_Id INNER JOIN
                  dbo.Fiscal_Year ON dbo.Main_Expens_Voucher.fiscal_year = dbo.Fiscal_Year.Fiscal_Year_Id

				  where Main_Expens_Voucher.MainExpensVoucherDate between @StartDate and @EndDate and
				 dbo.Main_Expens_Voucher.funds = @FundName
				  or dbo.Main_Expens_Voucher.currencies = @CurrenName  or
				  dbo.Main_Expens_Voucher.Main_ExpensVoucher_Number = @MainExpensVoucherNumber or
				  Main_Expens_Voucher.MainExpensVoucherStatus = @MainExpensVoucherStatus 
				  --Main_Expens_Voucher.IsDelete = @IsDelete

				  Group By dbo.Main_Expens_Voucher.Main_ExpensVoucher_Number, dbo.Main_Expens_Voucher.MainExpensVoucherAmount_RLY,  dbo.Currencies.CurrenName, 
                  dbo.Currencies.CurreType, dbo.Funds.FundName, dbo.Main_Expens_Voucher.MainExpensVoucherDate

	END
	ELSE
	BEGIN
	 SELECT  dbo.Main_Expens_Voucher.Main_ExpensVoucher_Number, dbo.Main_Expens_Voucher.MainExpensVoucherAmount_RLY,  dbo.Currencies.CurrenName, 
                  dbo.Currencies.CurreType, dbo.Funds.FundName, dbo.Main_Expens_Voucher.MainExpensVoucherDate

    FROM     dbo.Main_Expens_Voucher INNER JOIN

                  dbo.Detailed_Expens_Voucher ON dbo.Main_Expens_Voucher.Main_ExpensVoucher_Number = dbo.Detailed_Expens_Voucher.main_expens_voucher_number INNER JOIN
                  dbo.Currencies ON dbo.Main_Expens_Voucher.currencies = dbo.Currencies.Currencies_Id INNER JOIN
                  dbo.Funds ON dbo.Main_Expens_Voucher.funds = dbo.Funds.Funds_Id INNER JOIN
                  dbo.Fiscal_Year ON dbo.Main_Expens_Voucher.fiscal_year = dbo.Fiscal_Year.Fiscal_Year_Id

				  where Main_Expens_Voucher.MainExpensVoucherDate between @StartDate and @EndDate
				  --and dbo.Funds.FundName = @FundName
				  --and dbo.Currencies.CurrenName = @CurrenName  and
				  --dbo.Main_Expens_Voucher.Main_ExpensVoucher_Number = @MainExpensVoucherNumber
				   
				 

				  Group By dbo.Main_Expens_Voucher.Main_ExpensVoucher_Number, dbo.Main_Expens_Voucher.MainExpensVoucherAmount_RLY,  dbo.Currencies.CurrenName, 
                  dbo.Currencies.CurreType, dbo.Funds.FundName, dbo.Main_Expens_Voucher.MainExpensVoucherDate
	END
END
GO


