using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XternalDevLib
{
    class DBEntity
    {
        DevLib Xlib = new DevLib();
        public bool DB_Update()
        {
            bool rtnFlag = false;
            try
            {


                #region Company Specific

                /// Function


                /// View


                /// Procedure

                #endregion




            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "DBEntity.DB_Update()");
                rtnFlag = false;
            }
            return rtnFlag;
        }

        public bool Execute(string sqlType, string sqlName, string sqlQuery)
        {
            bool rtnFlag = false;
            try
            {
                if (Xlib.ExistsDBEntity(sqlName, sqlType))
                {
                    rtnFlag = true;
                }
                else
                {
                    Xlib.ExecuteNonQuery(sqlQuery);
                    rtnFlag = true;
                }

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "DBEntity.Execute()");
                rtnFlag = false;
            }
            return rtnFlag;
        }

        #region Functions "F"

        //xf_DateAdd
        public bool xf_DateAdd()
        {
            bool rtnFlag = false;
            try
            {
                string sqlType = "F";
                string sqlName = "xf_DateAdd";


                #region SQL Query

                string sqlQuery = @" Create Function xf_DateAdd
        (
            @interval varchar(10)
            , @increment int
            , @expression int
        )

        Returns int


        as
        begin


                Declare @rtnValue int
                Declare @sDate dateTime

                Select @sDate = Case When LEN(@expression) = 14 Then dbo.fCore_IntToDateTime(@expression)

                                     When LEN(@expression) = 9 Then dbo.IntToDate(@expression)

                                     Else GetDate()

                                End


                If  UPPER(@interval) in ('YEAR', 'YYYY', 'YY', 'Y')

                begin
                        Select  @sDate = DATEADD(YEAR, @increment, @sDate)

                end
                Else If UPPER(@interval) in ('MONTH', 'MM', 'M')

                begin
                        Select  @sDate = DATEADD(MONTH, @increment, @sDate)

                end
                Else If UPPER(@interval) in ('DAY', 'DD', 'D')

                begin
                        Select  @sDate = DATEADD(DAY, @increment, @sDate)

                end
                Else

                begin
                        Select  @sDate = dbo.IntToDate(@expression)

                end

                Select  @rtnValue = dbo.DateToInt(@sDate)


                Return IsNull(@rtnValue,0)

		end";

                #endregion
                rtnFlag = Execute(sqlType, sqlName, sqlQuery);

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "DBEntity.xf_DateAdd()");
                rtnFlag = false;
            }
            return rtnFlag;
        }

        //xf_AmortizationCalculation
        public bool xf_AmortizationCalculation()
        {
            bool rtnFlag = false;
            try
            {
                string sqlType = "F";
                string sqlName = "xf_AmortizationCalculation";


                #region SQL Query

                string sqlQuery = @" Create Function xf_AmortizationCalculation
		(
			@iStartDate int --= dbo.DateToInt('2020-01-01')
			, @iEndDate int --= dbo.DateToInt('2020-02-25')
			, @iLastPostDate int --= 0 --dbo.DateToInt('2020-01-31')
			, @iTerminationDate int --=  0--dbo.DateToInt('2020-06-30')

			, @iCalStartDate int --= dbo.DateToInt('2020-02-01')
			, @iCalEndDate int --= dbo.DateToInt('2020-02-29')
			, @iInvType int	--1=Monthly, 2=Quarterly, 3=Half Yearly, 4=Yearly
			
			, @iOutPutId int	-- 1=StartDate, 2=EndDate, 3=NextPostDate, 4=No.OfDays, 5=TotalContractDays
		)
		Returns varchar(250)

		as
		begin
		
				Declare @rtnValue varchar(250)

				Declare @NextPostDate int
				Declare @SDate int
				Declare @EDate int
				Declare @FinalSDate Date
				Declare @FinalEDate Date

				Declare @EndDate int --- Used to get Total No. Of Days 


				--- Set Start Date for Calculation 
				Select @SDate = Case When @iLastPostDate > @iStartDate Then dbo.xf_DateAdd('Day',1,@iLastPostDate) Else @iStartDate End

				

				--- Set End Date for Calculation 
				Select @iTerminationDate = Case When @iTerminationDate = 0 Then @iEndDate Else @iTerminationDate End
				Select @EndDate = Case When @iTerminationDate < @iEndDate Then @iTerminationDate Else @iEndDate End
				Select @EDate = Case When @EndDate > @iCalEndDate Then @iCalEndDate Else @EndDate End


				--- Get Next Posting Date
				Select @NextPostDate = dbo.xf_DateAdd('Day',-1,(Case When @iInvType = 4 Then dbo.xf_DateAdd('Year',1,@SDate)
											When @iInvType = 3 Then dbo.xf_DateAdd('Month',6,@SDate)
											When @iInvType = 2 Then dbo.xf_DateAdd('Month',3,@SDate)
											When @iInvType = 1 Then dbo.xf_DateAdd('Month',1,@SDate)
											Else dbo.xf_DateAdd('Month',1,@SDate)
										End))
				Select @NextPostDate = Case When @NextPostDate > @EDate Then @EDate Else @NextPostDate End



				Select @FinalSDate  = dbo.IntToDate(@SDate)
						, @FinalEDate  = dbo.IntToDate(@EDate)

				if @iOutPutId = 1
				begin
						Select @rtnValue = Format(dbo.IntToDate(@SDate),'yyyy-MM-dd')
				end
				else if @iOutPutId = 2
				begin
						Select @rtnValue = Format(dbo.IntToDate(@EDate),'yyyy-MM-dd')
				end
				else if @iOutPutId = 3
				begin
						Select @rtnValue = Format(dbo.IntToDate(@NextPostDate),'yyyy-MM-dd')
				end
				else if @iOutPutId = 4
				begin
						Select @rtnValue = DATEDIFF(Day,@FinalSDate,@FinalEDate) + 1
				end
				else if @iOutPutId = 5
				begin
						Select @rtnValue = DATEDIFF(Day,dbo.IntToDate(@iStartDate),dbo.IntToDate(@iEndDate)) + 1
				end
				else 
				begin
						Select @rtnValue = -1
				end


				Return IsNull(@rtnValue,-1)

			end";

                #endregion
                rtnFlag = Execute(sqlType, sqlName, sqlQuery);

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "DBEntity.xf_AmortizationCalculation()");
                rtnFlag = false;
            }
            return rtnFlag;
        }
        #endregion


        #region Views "V"


        #endregion


        #region Procedure "P"
        
        //xsp_PrePayment_List
        public bool xsp_PrePayment_List()
        {
            bool rtnFlag = false;
            try
            {
                string sqlType = "P";
                string sqlName = @"xsp_PrePayment_List";


                #region SQL Query

                string sqlQuery = @" Create Procedure xsp_PrePayment_List  
         
  @iStartDate int      --= dbo.DateToInt('2020/05/01')  
  , @iEndDate int      --= dbo.DateToInt('2020/05/31')  
  as        
  begin        
  
  Declare @t_Result1 Table(iMasterId int, SelStartDate date, SelEndDate date, NoOfDays int, NextPostDate date, TotalDays int )  
  
  Insert Into @t_Result1  
    Select pp.iMasterId  
       , dbo.xf_AmortizationCalculation(ppu.StartDate,ppu.EndDate,ppu.LastPosted, ppu.EndDate, @iStartDate,@iEndDate,1,1) [StartDate]  
       , dbo.xf_AmortizationCalculation(ppu.StartDate,ppu.EndDate,ppu.LastPosted, ppu.EndDate, @iStartDate,@iEndDate,1,2) [EndDate]  
       , dbo.xf_AmortizationCalculation(ppu.StartDate,ppu.EndDate,ppu.LastPosted, ppu.EndDate, @iStartDate,@iEndDate,1,4) [NoOfDays]  
       , dbo.xf_AmortizationCalculation(ppu.StartDate,ppu.EndDate,ppu.LastPosted, ppu.EndDate, @iStartDate,@iEndDate,1,3) [NextPostingDate]  
       , dbo.xf_AmortizationCalculation(ppu.StartDate,ppu.EndDate,ppu.LastPosted, ppu.EndDate, @iStartDate,@iEndDate,1,5) [TotalDays]  
  
    From mCore_Prepayments pp      
      inner join muCore_Prepayments ppu on ppu.iMasterId = pp.iMasterId  
    Where pp.iMasterId > 0  And pp.iStatus = 0      
      And (ppu.StartDate > 0 Or ppu.EndDate > 0)        
      And convert(varchar(6),dbo.IntToDate(@iStartDate),112) Between   
       convert(varchar(6),dbo.IntToDate(Case When ppu.LastPosted = 0 Then ppu.StartDate Else dbo.xf_DateAdd('Day',1,ppu.LastPosted) End),112)  
       And convert(varchar(6),dbo.IntToDate(ppu.EndDate),112)  
  
  
  Select pp.sName [PrePayment]        
		, emp.sName [Employee]  
		, rc.sName [RevenueChannel]  
  
		, Case When ppu.StartDate = 0 Then '' Else Convert(varchar(15),dbo.IntToDate(ppu.StartDate),103) End [StartDate]   
		, Case When ppu.EndDate = 0 Then '' Else Convert(varchar(15),dbo.IntToDate(ppu.EndDate),103) End [EndDate]   
		, Case When ppu.LastPosted = 0 Then '' Else Convert(varchar(15),dbo.IntToDate(ppu.LastPosted),103) End [LastPosted]   
		, tr1.TotalDays [NoOfDays]  
  
		, ppu.iMasterId [iMasterId]        
  
  From mCore_Prepayments pp      
    inner join @t_Result1 tr1 on tr1.iMasterId = pp.iMasterId  
    inner join muCore_Prepayments ppu on ppu.iMasterId = pp.iMasterId  
	left join mPay_Employee emp on emp.iMasterId = ppu.Employee
	left join mCore_RevenueChannel rc on rc.iMasterId = ppu.RevenueChannel

  Where pp.iMasterId > 0  And pp.iStatus = 0      
    And dbo.DateToInt(tr1.NextPostDate) <= @iEndDate  
        
  end";

                #endregion
                rtnFlag = Execute(sqlType, sqlName, sqlQuery);

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "DBEntity.xsp_PrePayment_List()");
                rtnFlag = false;
            }
            return rtnFlag;
        }

        //xsp_PrePayment_Posting
        public bool xsp_PrePayment_Posting()
        {
            bool rtnFlag = false;
            try
            {
                string sqlType = "P";
                string sqlName = "xsp_PrePayment_Posting";


                #region SQL Query

                string sqlQuery = @" Create Procedure xsp_PrePayment_Posting  
  
  @iMasterId int --= 2  
  , @iStartDate int      --= dbo.DateToInt('2020/05/01')  
  , @iEndDate int      --= dbo.DateToInt('2020/05/31')  
  
  as  
  begin  
  
  
  Declare @NoOfDays int  
    , @TotalDays int  
    , @AnnualRent decimal(18,7)  
    , @EDate int  
  
  
  --- Variables for Amount Calculation  
  Select   
    @NoOfDays = dbo.xf_AmortizationCalculation(ppu.StartDate,ppu.EndDate,ppu.LastPosted, ppu.EndDate, @iStartDate,@iEndDate,1,4)   
    , @TotalDays = dbo.xf_AmortizationCalculation(ppu.StartDate,ppu.EndDate,ppu.LastPosted, ppu.EndDate, @iStartDate,@iEndDate,1,5)   
    , @AnnualRent = ppu.PrepaidAmount   
    , @EDate = ppu.EndDate  
  
  From mCore_Prepayments pp      
    inner join muCore_Prepayments ppu on ppu.iMasterId = pp.iMasterId  
  Where pp.iMasterId = @iMasterId  
  
  --- Last Month Amount calculation to Eliminate decimal issues   
  if @EDate <= @iEndDate  
  begin  
    Select   
      @AnnualRent = d.mAmount2
    From tCore_Header_0 h  
      inner join tCore_Data_0 d on d.iHeaderId = h.iHeaderId  
        And h.iVoucherType = 8705  
        And h.bSuspended = 0 And h.bCancelled = 0 And d.iType = 0  
      inner join tCore_Data_Tags_0 tag on tag.iBodyId = d.iBodyId   
    Where tag.iTag3005 = @iMasterId    
  end  
  
  
  --- Posting Amount Calculation  
  Select @AnnualRent = (@AnnualRent / @TotalDays) * @NoOfDays  
      
  
  --- Header   
  Select   
		'PP1' [DocNo]
		, @iEndDate [Date]
		, ppu.Currency [Currency]
		, IsNull((Select Top (1) fExchangeRate From vCore_CurrencyExchange Where iBaseCurrencyId = 7 And iCurrencyId = 2 Order By iEffectiveDate Desc),1) [ExchangeRate]
		, ppu.Branch [Branches]
		, pp.iMasterId [Prepayments]
		, '' [sNerration]  
		

		, 'Prepayment Journal' [*PostVoucher]  --- this voucher will be posted  
  
  From mCore_Prepayments pp    
    inner join muCore_Prepayments ppu on ppu.iMasterId = pp.iMasterId  
  Where pp.iMasterId = @iMasterId  
  
  
  
  --- Body  
   --- Rent - Debit - Credit  
  Select  
		 ppu.RevenueChannel [Revenue Channel]
		, ppu.Employee [Employee]
		, ppu. DebitAccount [DrAccount]  
		, ppu.CreditAccount [CrAccount]  
		, @AnnualRent [Amount]  
		, '' [sRemarks]  
  From mCore_Prepayments pp    
    inner join muCore_Prepayments ppu on ppu.iMasterId = pp.iMasterId  
  Where pp.iMasterId = @iMasterId  
  
  end";

                #endregion
                rtnFlag = Execute(sqlType, sqlName, sqlQuery);

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "DBEntity.xsp_PrePayment_Posting()");
                rtnFlag = false;
            }
            return rtnFlag;
        }

        //xsp_Update_PrePayment_PostedDate
        public bool xsp_Update_PrePayment_PostedDate()
        {
            bool rtnFlag = false;
            try
            {
                string sqlType = "P";
                string sqlName = "xsp_Update_PrePayment_PostedDate";


                #region SQL Query

                string sqlQuery = @" Create Procedure xsp_Update_PrePayment_PostedDate  
  
  @PostedDate int  
  , @iMasterId int  
  
  as  
  begin  
  
   Update muCore_Prepayments Set LastPosted = @PostedDate Where iMasterId = @iMasterId  
  
  end";

                #endregion
                rtnFlag = Execute(sqlType, sqlName, sqlQuery);

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "DBEntity.xsp_Update_PrePayment_PostedDate()");
                rtnFlag = false;
            }
            return rtnFlag;
        }

        #endregion


        #region Sample
        public bool Sample()
        {
            bool rtnFlag = false;
            try
            {
                string sqlType = "F,V,P";
                string sqlName = "Sample";


                #region SQL Query

                string sqlQuery = @" ";

                #endregion
                rtnFlag = Execute(sqlType, sqlName, sqlQuery);

            }
            catch (Exception ex)
            {
                Xlib.ErrLog(ex, "DBEntity.Sample()");
                rtnFlag = false;
            }
            return rtnFlag;
        }
        #endregion
    }
}
