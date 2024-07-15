alter procedure [dbo].[sp_IntApi_InsertAuditLog](@Module varchar(255),
@Action varchar(255),
@Description varchar(MAX),
@CreatedBy varchar(255),
@ClientIP varchar(255),
@ActionType varchar(255),
@Controler varchar(255))
as
begin

declare @ID as varchar(10)
SELECT @ID=[ID]
FROM [dbo].[tbl_AuditLog_ActionMap] where [Module]=@Module and [Controller]=@Controler and [Action]=@Action

if @ID is not null
INSERT INTO [dbo].[tbl_auditlog]
           ([Module]
           ,[Action]
           ,[Description]
           ,[CreatedBy]
		   ,ClientIP
		   ,CreatedDateTime,ActionType,Controler,ActionMap_ID)
     VALUES
           (@Module,@Action,@Description,@CreatedBy,@ClientIP,getdate(),@ActionType,@Controler,@ID)
else
	set @ID=-1
	INSERT INTO [dbo].[tbl_auditlog]
           ([Module]
           ,[Action]
           ,[Description]
           ,[CreatedBy]
		   ,ClientIP
		   ,CreatedDateTime,ActionType,Controler,ActionMap_ID)
     VALUES
           (@Module,@Action,@Description,@CreatedBy,@ClientIP,getdate(),@ActionType,@Controler,@ID)
end


