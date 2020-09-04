
CREATE TABLE [dbo].[PAYMENT_DETAILS_BACK](
	[PD_ID] [int] NULL,
	[PD_AMOUNT] [decimal](18, 0) NOT NULL,
	[PD_FROM_ACC] [varchar](100) NOT NULL,
	[PD_TO_ACC] [int] NOT NULL,
	[PD_REFERANCE_NO] [varchar](50) NOT NULL,
	[PD_TYPE] [varchar](500) NOT NULL,
	[PD_DETAILS] [varchar](500) NULL,
	[ID] [int]  NOT NULL,
	[PD_TRNC_ID] [int] NULL,
	[PD_BRANCH_ID] [int] NULL,
	[PD_DATE] [datetime] NULL,
	[PD_CRTD_AT] [datetime] NULL,
	[PD_CRTD_BY] [varchar](50) NULL,
	[PD_UPDT_BY] [varchar](50) NULL,
	[PD_UPDT_AT] [datetime] NULL,
	[PD_DLTD_AT] [datetime] NULL,
	[PD_DLTD_BY] [varchar](50) NULL
) ON [PRIMARY]
GO

insert into [PAYMENT_DETAILS_BACK] select distinct * from PAYMENT_DETAILS

alter table PAYMENT_DETAILS disable trigger all

set IDENTITY_INSERT PAYMENT_DETAILS ON 

delete from PAYMENT_DETAILS;

insert into PAYMENT_DETAILS ([PD_ID],
	[PD_AMOUNT] ,
	[PD_FROM_ACC],
	[PD_TO_ACC] ,
	[PD_REFERANCE_NO],
	[PD_TYPE],
	[PD_DETAILS] ,
	[ID],
	[PD_TRNC_ID],
	[PD_BRANCH_ID] ,
	[PD_DATE],
	[PD_CRTD_AT],
	[PD_CRTD_BY],
	[PD_UPDT_BY],
	[PD_UPDT_AT],
	[PD_DLTD_AT],
	[PD_DLTD_BY])  select distinct [PD_ID],
	[PD_AMOUNT] ,
	[PD_FROM_ACC],
	[PD_TO_ACC] ,
	[PD_REFERANCE_NO],
	[PD_TYPE],
	[PD_DETAILS] ,
	[ID],
	[PD_TRNC_ID],
	[PD_BRANCH_ID] ,
	[PD_DATE],
	[PD_CRTD_AT],
	[PD_CRTD_BY],
	[PD_UPDT_BY],
	[PD_UPDT_AT],
	[PD_DLTD_AT],
	[PD_DLTD_BY] from PAYMENT_DETAILS_BACK

set IDENTITY_INSERT PAYMENT_DETAILS off 

alter table PAYMENT_DETAILS enable trigger all




select * from PAYMENT_DETAILS order by 1