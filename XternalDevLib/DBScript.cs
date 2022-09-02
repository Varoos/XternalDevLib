using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace DiamondShoes
//{
class DBScript
{
     DevLib Xlib = new DevLib();
    public bool DB_Update()
    {
        bool rtnFlag = false;
        try
        {


            /// Function

            rtnFlag = xf_GetStockBalance();
            rtnFlag = xf_GetVatPerc();
            rtnFlag = xf_StringToTable();
            rtnFlag = xf_StringToTable_Value();



            /// View

            rtnFlag = xv_Links();
            rtnFlag = xvCore_Data_0();

            /// Procedure



        }
        catch (Exception ex)
        {
            Xlib.ErrLog(ex, "DBEntity.DB_Update()");
            rtnFlag = false;
        }
        return rtnFlag;
    }

    private bool Execute(string sqlType, string sqlName, string sqlQuery)
    {
        bool rtnFlag = false;
        try
        {
            if (Xlib.ExistsDBEntity(sqlName, sqlType))
            {
                sqlQuery = "Alter " + sqlQuery;
            }
            else
            {
                sqlQuery = "Create " + sqlQuery;
            }

            if (Xlib.ExecuteNonQuery(sqlQuery)< 0)
            {
                rtnFlag = false;
            }
            rtnFlag = true;

        }
        catch (Exception ex)
        {
            Xlib.ErrLog(ex, "DBEntity.Execute()");
            rtnFlag = false;
        }
        return rtnFlag;
    }


    #region Focus Common

    #region Functions

    private bool xf_GetStockBalance()
    {
        bool rtnFlag = false;
        try
        {
            string sqlType = "F";
            string sqlName = "xf_GetStockBalance";


            #region SQL Query

            string sqlQuery = @" FUNCTION xf_GetStockBalance
                    (  
                        @iDate INT
						, @iProductId INT  
						, @iInvTag INT
						
                    )  
                    RETURNS decimal(18,2)  
                    AS  
                    BEGIN  
                        DECLARE @iStockQty decimal(18,2) = 0;  
                        SELECT @iStockQty = SUM(fQiss + fQrec)  
                        FROM tCore_ibals_0   
                        WHERE iDate <= @iDate 
								AND iProduct = @iProductId  
								AND (iInvTag = @iInvTag Or @iInvTag = 0) 
                        GROUP BY iProduct  

                        RETURN @iStockQty  
                    END";

            #endregion
            rtnFlag = Execute(sqlType, sqlName, sqlQuery);

        }
        catch (Exception ex)
        {
            Xlib.ErrLog(ex, "DBEntity.xf_GetStockBalance()");
            rtnFlag = false;
        }
        return rtnFlag;
    }

    private bool xf_GetVatPerc()
    {
        bool rtnFlag = false;
        try
        {
            string sqlType = "F";
            string sqlName = "xf_GetVatPerc";


            #region SQL Query

            string sqlQuery = @"function xf_GetVatPerc
	(
		@iTaxCode int
		, @iTaxCat int
		, @iJuris int
		, @iPlaceSupply int
	)
	Returns decimal(18,2)

	as
	begin
			Declare @fPerc decimal(18,2) = 0
			Select @fPerc = fPerc 
			From mCore_TaxRate 
			Where iTaxCode = @iTaxCode
					And iTaxCat = @iTaxCat
					And iJuris = @iJuris
					And iPlaceSupply = @iPlaceSupply


			return IsNull(@fPerc,0)
	end";

            #endregion
            rtnFlag = Execute(sqlType, sqlName, sqlQuery);

        }
        catch (Exception ex)
        {
            Xlib.ErrLog(ex, "DBEntity.xf_GetVatPerc()");
            rtnFlag = false;
        }
        return rtnFlag;
    }

    private bool xf_StringToTable()
    {
        bool rtnFlag = false;
        try
        {
            string sqlType = "F";
            string sqlName = "xf_StringToTable";


            #region SQL Query

            string sqlQuery = @" FUNCTION xf_StringToTable ( @StringInput VARCHAR(8000), @Delimiter nvarchar(1))
RETURNS @OutputTable TABLE ( iMasterId int )
AS
BEGIN

    DECLARE @iMasterId   int

    WHILE LEN(@StringInput) > 0
    BEGIN
        SET @iMasterId      = LEFT(@StringInput, 
                                ISNULL(NULLIF(CHARINDEX(@Delimiter, @StringInput) - 1, -1),
                                LEN(@StringInput)))
        SET @StringInput = SUBSTRING(@StringInput,
                                     ISNULL(NULLIF(CHARINDEX(@Delimiter, @StringInput), 0),
                                     LEN(@StringInput)) + 1, LEN(@StringInput))

        INSERT INTO @OutputTable ( [iMasterId] )
        VALUES ( @iMasterId )
    END

    RETURN
END";

            #endregion
            rtnFlag = Execute(sqlType, sqlName, sqlQuery);

        }
        catch (Exception ex)
        {
            Xlib.ErrLog(ex, "DBEntity.xf_StringToTable()");
            rtnFlag = false;
        }
        return rtnFlag;
    }

    private bool xf_StringToTable_Value()
    {
        bool rtnFlag = false;
        try
        {
            string sqlType = "F";
            string sqlName = "xf_StringToTable_Value";


            #region SQL Query

            string sqlQuery = @" FUNCTION xf_StringToTable_Value ( @StringInput VARCHAR(8000), @Delimiter nvarchar(1))
RETURNS @OutputTable TABLE ( iRowNo int primary key identity(1,1), sValue nvarchar(25) )
AS
BEGIN

    DECLARE @sValue nvarchar(25)

    WHILE LEN(@StringInput) > 0
    BEGIN
        SET @sValue      = LEFT(@StringInput, 
                                ISNULL(NULLIF(CHARINDEX(@Delimiter, @StringInput) - 1, -1),
                                LEN(@StringInput)))
        SET @StringInput = SUBSTRING(@StringInput,
                                     ISNULL(NULLIF(CHARINDEX(@Delimiter, @StringInput), 0),
                                     LEN(@StringInput)) + 1, LEN(@StringInput))

        INSERT INTO @OutputTable ( sValue )
        VALUES ( @sValue )
    END

    RETURN
END";

            #endregion
            rtnFlag = Execute(sqlType, sqlName, sqlQuery);

        }
        catch (Exception ex)
        {
            Xlib.ErrLog(ex, "DBEntity.xf_StringToTable_Value()");
            rtnFlag = false;
        }
        return rtnFlag;
    }

    #endregion


    #region Views

    private bool xv_Links()
    {
        bool rtnFlag = false;
        try
        {
            string sqlType = "V";
            string sqlName = "xv_Links";


            #region SQL Query

            string sqlQuery = @" View xv_Links

                                        as

		                                        Select 
					                                        base.iRefId [base_iRefId]
					                                        , base.iTransactionId [base_iTransactionId]
					                                        , base.iLinkId [base_iLinkId]
					                                        , base.bBase [base_bBase]
					                                        , base.fValue [base_fValue]
					                                        , base.bClosed [base_bClosed]
					                                        , base.iUserId [base_iUserId]
					                                        , base.iCDate [base_iCDate]
					                                        , base.iTime   [base_iTime]
					                                        , lnk.iRefId [lnk_iRefId]
					                                        , lnk.iTransactionId [lnk_iTransactionId]
					                                        , lnk.iLinkId [lnk_iLinkId]
					                                        , lnk.bBase [lnk_bBase]
					                                        , lnk.fValue [lnk_fValue]
					                                        , lnk.bClosed [lnk_bClosed]
					                                        , lnk.iUserId [lnk_iUserId]
					                                        , lnk.iCDate [lnk_iCDate]
					                                        , lnk.iTime   [lnk_iTime]
		                                        From (
					                                        Select iRefId
							                                        , iTransactionId
							                                        , iLinkId
							                                        , bBase
							                                        , fValue
							                                        , bClosed
							                                        , iUserId
							                                        , iCDate
							                                        , iTime 
					                                        From tCore_Links_0
					                                        Where bBase = 1
				                                        ) base
			                                        Left join 
					                                        (
					                                        Select iRefId
							                                        , iTransactionId
							                                        , iLinkId
							                                        , bBase
							                                        , fValue
							                                        , bClosed
							                                        , iUserId
							                                        , iCDate
							                                        , iTime 
					                                        From tCore_Links_0
					                                        Where bBase = 0
				                                        ) lnk on base.iRefId = lnk.iRefId";

            #endregion
            rtnFlag = Execute(sqlType, sqlName, sqlQuery);

        }
        catch (Exception ex)
        {
            Xlib.ErrLog(ex, "DBEntity.xv_Links()");
            rtnFlag = false;
        }
        return rtnFlag;
    }

    private bool xvCore_Data_0()
    {
        bool rtnFlag = false;
        try
        {
            string sqlType = "V";
            string sqlName = "xvCore_Data_0";


            #region SQL Query

            string sqlQuery = @" view xvCore_Data_0  
     
     
   AS        
                 
             SELECT iMasterId [iAccount]  
     , iDate [iDate]  
     , Debit [Debit]  
     , Credit [Credit]   
     , iHeaderId [iHeaderId]  
     , iBodyId [iBodyId]  
     , iFaTag [iFaTag]  
     , iInvTag [iInvTag]    
     , iProduct [iProduct]  
     , mRate [mRate]  
     , fQuantity [fQuantity]  
     , iUnit [iUnit]  
     , mGross [mGross]  
     , mStockValue[mStockValue]  
	 , sVoucherNo [sVoucherNo]
	 , iVoucherType [iVoucherType]
  
             FROM        
             (        
              SELECT iBookNo[iMasterId],iDate,        
              CASE WHEN mAmount2 < 0 THEN mAmount2 ELSE 0 END Debit,         
              CASE WHEN mAmount2 > 0 THEN mAmount2 ELSE 0 END Credit   
				 , tCore_Header_0.iHeaderId  
				 , tCore_Data_0.iBodyId  
				 , tCore_Data_0.iFaTag  
				 , tCore_Data_0.iInvTag  
				 , IsNull(tCore_Indta_0.iProduct,0) iProduct  
				 , IsNull(tCore_Indta_0.mRate,0) mRate  
				 , IsNull(tCore_Indta_0.fQuantity,0) fQuantity  
				 , IsNull(tCore_Indta_0.iUnit,0) iUnit  
				 , IsNull(tCore_Indta_0.mGross,0) mGross  
				 , IsNull(tCore_Indta_0.mStockValue,0) mStockValue  
				 , cCore_Vouchers_0.sAbbr + ':' + tCore_Header_0.sVoucherNo [sVoucherNo]
				 , tCore_Header_0.iVoucherType [iVoucherType]
              FROM         
              tCore_Data_0         
              JOIN tCore_Header_0 ON tCore_Data_0.iHeaderId = tCore_Header_0.iHeaderId        
              JOIN cCore_Vouchers_0 ON cCore_Vouchers_0.iVoucherType=tCore_Header_0.iVoucherType        
              JOIN mCore_Account ON tCore_Data_0.iCode = mCore_Account.iMasterId      
			  LEFT JOIN tCore_Indta_0 ON tCore_Indta_0.iBodyId = tCore_Data_0.iBodyId  
              WHERE cCore_Vouchers_0.bUpdateFA = 1 AND tCore_Data_0.bSuspendUpdateFA <> 1 AND bSuspended=0        
                      
              UNION ALL        
              SELECT iCode[iMasterId],iDate,        
              CASE WHEN mAmount1 < 0 THEN mAmount1 ELSE 0 END Debit,         
              CASE WHEN mAmount1 > 0 THEN mAmount1 ELSE 0 END Credit   
				 , tCore_Header_0.iHeaderId  
				 , tCore_Data_0.iBodyId  
				 , tCore_Data_0.iFaTag  
				 , tCore_Data_0.iInvTag     
				 , IsNull(tCore_Indta_0.iProduct,0) iProduct  
				 , IsNull(tCore_Indta_0.mRate,0) mRate  
				 , IsNull(tCore_Indta_0.fQuantity,0) fQuantity  
				 , IsNull(tCore_Indta_0.iUnit,0) iUnit  
				 , IsNull(tCore_Indta_0.mGross,0) mGross  
				 , IsNull(tCore_Indta_0.mStockValue,0) mStockValue  
				 , cCore_Vouchers_0.sAbbr + ':' + tCore_Header_0.sVoucherNo [sVoucherNo]
				 , tCore_Header_0.iVoucherType [iVoucherType]
        
              FROM         
              tCore_Data_0          
              JOIN tCore_Header_0 ON tCore_Data_0.iHeaderId = tCore_Header_0.iHeaderId        
              JOIN cCore_Vouchers_0 ON cCore_Vouchers_0.iVoucherType=tCore_Header_0.iVoucherType        
     LEFT JOIN tCore_Indta_0 ON tCore_Indta_0.iBodyId = tCore_Data_0.iBodyId  
              WHERE cCore_Vouchers_0.bUpdateFA = 1 AND tCore_Data_0.bSuspendUpdateFA <> 1 AND bSuspended=0        
      
              UNION ALL        
              SELECT iCode,iDate,CASE WHEN mAmount1 < 0 THEN mAmount1 ELSE 0 END Debit,         
              CASE WHEN mAmount1 > 0 THEN mAmount1 ELSE 0 END Credit    
				 , tCore_Header_0.iHeaderId  
				 , tCore_Data_0.iBodyId  
				 , tCore_Data_0.iFaTag  
				 , tCore_Data_0.iInvTag    
				 , IsNull(tCore_Indta_0.iProduct,0) iProduct  
				 , IsNull(tCore_Indta_0.mRate,0) mRate  
				 , IsNull(tCore_Indta_0.fQuantity,0) fQuantity  
				 , IsNull(tCore_Indta_0.iUnit,0) iUnit  
				 , IsNull(tCore_Indta_0.mGross,0) mGross  
				 , IsNull(tCore_Indta_0.mStockValue,0) mStockValue    
				 , cCore_Vouchers_0.sAbbr + ':' + tCore_Header_0.sVoucherNo [sVoucherNo]
				 , tCore_Header_0.iVoucherType [iVoucherType]
              FROM         
              tCore_Data_0         
              JOIN tCore_Header_0 ON tCore_Data_0.iHeaderId = tCore_Header_0.iHeaderId        
              JOIN cCore_Vouchers_0 ON cCore_Vouchers_0.iVoucherType=tCore_Header_0.iVoucherType    
     LEFT JOIN tCore_Indta_0 ON tCore_Indta_0.iBodyId = tCore_Data_0.iBodyId      
              WHERE cCore_Vouchers_0.bUpdateFA = 1 AND tCore_Data_0.bSuspendUpdateFA <> 1 AND bSuspended=0        
    and tCore_Header_0.iVoucherType=256 and iCode=2        
      
      
              UNION ALL        
              SELECT iBookNo,iDate,CASE WHEN mAmount2 < 0 THEN mAmount2 ELSE 0 END Debit,         
              CASE WHEN mAmount2 > 0 THEN mAmount2 ELSE 0 END Credit    
				 , tCore_Header_0.iHeaderId  
				 , tCore_Data_0.iBodyId  
				 , tCore_Data_0.iFaTag  
				 , tCore_Data_0.iInvTag      
				 , IsNull(tCore_Indta_0.iProduct,0) iProduct  
				 , IsNull(tCore_Indta_0.mRate,0) mRate  
				 , IsNull(tCore_Indta_0.fQuantity,0) fQuantity  
				 , IsNull(tCore_Indta_0.iUnit,0) iUnit  
				 , IsNull(tCore_Indta_0.mGross,0) mGross  
				 , IsNull(tCore_Indta_0.mStockValue,0) mStockValue  
				 , cCore_Vouchers_0.sAbbr + ':' + tCore_Header_0.sVoucherNo [sVoucherNo]
				 , tCore_Header_0.iVoucherType [iVoucherType]
              FROM         
              tCore_Data_0         
              JOIN tCore_Header_0 ON tCore_Data_0.iHeaderId = tCore_Header_0.iHeaderId        
              JOIN cCore_Vouchers_0 ON cCore_Vouchers_0.iVoucherType=tCore_Header_0.iVoucherType     
     LEFT JOIN tCore_Indta_0 ON tCore_Indta_0.iBodyId = tCore_Data_0.iBodyId     
              WHERE cCore_Vouchers_0.bUpdateFA = 1 AND tCore_Data_0.bSuspendUpdateFA <> 1 AND bSuspended=0        
      and tCore_Header_0.iVoucherType=256 and iBookNo=2        
             )TempTable    ";

            #endregion
            rtnFlag = Execute(sqlType, sqlName, sqlQuery);

        }
        catch (Exception ex)
        {
            Xlib.ErrLog(ex, "DBEntity.xvCore_Data_0()");
            rtnFlag = false;
        }
        return rtnFlag;
    }

    #endregion


    #region Procedure


    #endregion


    #endregion


    #region Sample
    private bool Sample()
    {
        bool rtnFlag = false;
        try
        {
            string sqlType = "";
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
//}
