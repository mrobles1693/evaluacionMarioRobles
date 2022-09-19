USE [BD_MARIO_ROBLES]
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_update]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Personal_update]
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_select_by_id]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Personal_select_by_id]
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_select]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Personal_select]
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_insert]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Personal_insert]
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_delete]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Personal_delete]
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_update]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Hijo_update]
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_select_by_personal]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Hijo_select_by_personal]
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_select_by_id]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Hijo_select_by_id]
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_select]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Hijo_select]
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_insert]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Hijo_insert]
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_delete]    Script Date: 19/09/2022 01:30:21 ******/
DROP PROCEDURE [dbo].[sp_Hijo_delete]
GO
ALTER TABLE [dbo].[Hijo] DROP CONSTRAINT [FK_Personal_Hijo]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 19/09/2022 01:30:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Personal]') AND type in (N'U'))
DROP TABLE [dbo].[Personal]
GO
/****** Object:  Table [dbo].[Hijo]    Script Date: 19/09/2022 01:30:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Hijo]') AND type in (N'U'))
DROP TABLE [dbo].[Hijo]
GO