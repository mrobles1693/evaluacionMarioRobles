CREATE DATABASE BD_MARIO_ROBLES
GO

USE [BD_MARIO_ROBLES]
GO
/****** Object:  Table [dbo].[Hijo]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hijo](
	[idHijo] [int] IDENTITY(1,1) NOT NULL,
	[idPersonal] [int] NOT NULL,
	[TipoDoc] [varchar](10) NOT NULL,
	[NumeroDoc] [varchar](10) NOT NULL,
	[ApPaterno] [varchar](50) NOT NULL,
	[ApMaterno] [varchar](50) NOT NULL,
	[Nombre1] [varchar](50) NOT NULL,
	[Nombre2] [varchar](50) NULL,
	[NombreCompleto] [varchar](300) NOT NULL,
	[FechaNac] [date] NOT NULL,
 CONSTRAINT [PK_Hijo] PRIMARY KEY CLUSTERED 
(
	[idHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[idPersonal] [int] IDENTITY(1,1) NOT NULL,
	[TipoDoc] [varchar](10) NOT NULL,
	[NumeroDoc] [varchar](10) NOT NULL,
	[ApPaterno] [varchar](50) NOT NULL,
	[ApMaterno] [varchar](50) NOT NULL,
	[Nombre1] [varchar](50) NOT NULL,
	[Nombre2] [varchar](50) NULL,
	[NombreCompleto] [varchar](300) NOT NULL,
	[FechaNac] [date] NOT NULL,
	[FechaIngreso] [date] NOT NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[idPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hijo]  WITH CHECK ADD  CONSTRAINT [FK_Personal_Hijo] FOREIGN KEY([idPersonal])
REFERENCES [dbo].[Personal] ([idPersonal])
GO
ALTER TABLE [dbo].[Hijo] CHECK CONSTRAINT [FK_Personal_Hijo]
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_delete]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Hijo_delete]
	@idHijo int,
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Hijo WHERE idHijo = @idHijo)
		BEGIN
			set @msj= 'ID HIJO NO EXISTE'
		END
	ELSE
		BEGIN
			DELETE Hijo WHERE idHijo = @idHijo
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_insert]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Hijo_insert]
	@idHijo int output,
	@idPersonal int,
	@TipoDoc varchar(10),
	@NumeroDoc varchar(10),
	@ApPaterno varchar(50),
	@ApMaterno varchar(50),
	@Nombre1 varchar(50),
	@Nombre2 varchar(50),
	@NombreCompleto varchar(300),
	@FechaNac date,
	@msj varchar(100) output
AS
BEGIN
	IF EXISTS (SELECT * FROM Hijo WHERE TipoDoc = @TipoDoc AND NumeroDoc = @NumeroDoc)
		BEGIN
			set @msj= 'ESE TIPO Y NÚMERO DOCUMENTO YA ESTA REGISTRADO'
		END
	ELSE IF NOT EXISTS (SELECT * FROM Personal WHERE idPersonal = @idPersonal)
		BEGIN 
			set @msj= 'PERSONAL NO EXISTE'
		END
	ELSE
		BEGIN
			INSERT INTO Hijo (idPersonal, TipoDoc, NumeroDoc, ApPaterno, ApMaterno, Nombre1, Nombre2, NombreCompleto, FechaNac)
			VALUES (@idPersonal, @TipoDoc, @NumeroDoc, @ApPaterno, @ApMaterno, @Nombre1, @Nombre2, @NombreCompleto, @FechaNac)

			SET @idHijo = (SELECT scope_identity())
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_select]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Hijo_select]
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Hijo)
		BEGIN
			set @msj= 'NO HAY REGISTROS'
		END
	ELSE
		BEGIN
			SELECT * FROM Hijo
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_select_by_id]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Hijo_select_by_id]
	@idHijo int,
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Hijo WHERE idHijo = @idHijo)
		BEGIN
			set @msj= 'ID HIJO NO EXISTE'
		END
	ELSE
		BEGIN
			SELECT * FROM Hijo WHERE idHijo = @idHijo
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_select_by_personal]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Hijo_select_by_personal]
	@idPersonal int,
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Hijo WHERE idPersonal = @idPersonal)
		BEGIN
			set @msj= 'NO HAY REGISTROS'
		END
	ELSE
		BEGIN
			SELECT * FROM Hijo WHERE idPersonal = @idPersonal
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Hijo_update]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Hijo_update]
	@idHijo int,
	@idPersonal int,
	@TipoDoc varchar(10),
	@NumeroDoc varchar(10),
	@ApPaterno varchar(50),
	@ApMaterno varchar(50),
	@Nombre1 varchar(50),
	@Nombre2 varchar(50),
	@NombreCompleto varchar(300),
	@FechaNac date,
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Hijo WHERE idHijo = @idHijo)
		BEGIN
			set @msj= 'HIJO NO EXISTE'
		END
	ELSE
		BEGIN
			UPDATE Hijo 
			SET
				idPersonal = @idPersonal,
				TipoDoc = @TipoDoc, 
				NumeroDoc = @NumeroDoc, 
				ApPaterno = @ApPaterno, 
				ApMaterno = @ApMaterno, 
				Nombre1 = @Nombre1, 
				Nombre2 = @Nombre2, 
				NombreCompleto = @NombreCompleto, 
				FechaNac = @FechaNac
			WHERE
				idHijo = @idHijo
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_delete]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Personal_delete]
	@idPersonal int,
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Personal WHERE idPersonal = @idPersonal)
		BEGIN
			set @msj= 'ID PERSONAL NO EXISTE'
		END
	ELSE
		BEGIN
			DELETE Hijo WHERE idPersonal = @idPersonal
			DELETE Personal WHERE idPersonal = @idPersonal
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_insert]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Personal_insert]
	@idPersonal int output,
	@TipoDoc varchar(10),
	@NumeroDoc varchar(10),
	@ApPaterno varchar(50),
	@ApMaterno varchar(50),
	@Nombre1 varchar(50),
	@Nombre2 varchar(50),
	@NombreCompleto varchar(300),
	@FechaNac date,
	@FechaIngreso date,
	@msj varchar(100) output
AS
BEGIN
	IF EXISTS (SELECT * FROM Personal WHERE TipoDoc = @TipoDoc AND NumeroDoc = @NumeroDoc)
		BEGIN
			set @msj= 'ESE TIPO Y NÚMERO DOCUMENTO YA ESTA REGISTRADO'
		END
	ELSE
		BEGIN
			INSERT INTO Personal (TipoDoc, NumeroDoc, ApPaterno, ApMaterno, Nombre1, Nombre2, NombreCompleto, FechaNac, FechaIngreso)
			VALUES (@TipoDoc, @NumeroDoc, @ApPaterno, @ApMaterno, @Nombre1, @Nombre2, @NombreCompleto, @FechaNac, @FechaIngreso)

			SET @idPersonal = (SELECT scope_identity())
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_select]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Personal_select]
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Personal)
		BEGIN
			set @msj= 'NO HAY REGISTROS'
		END
	ELSE
		BEGIN
			SELECT * FROM Personal
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_select_by_id]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Personal_select_by_id]
	@idPersonal int,
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Personal WHERE idPersonal = @idPersonal)
		BEGIN
			set @msj= 'NO HAY REGISTROS'
		END
	ELSE
		BEGIN
			SELECT * FROM Personal WHERE idPersonal = @idPersonal
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Personal_update]    Script Date: 19/09/2022 01:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Personal_update]
	@idPersonal int,
	@TipoDoc varchar(10),
	@NumeroDoc varchar(10),
	@ApPaterno varchar(50),
	@ApMaterno varchar(50),
	@Nombre1 varchar(50),
	@Nombre2 varchar(50),
	@NombreCompleto varchar(300),
	@FechaNac date,
	@FechaIngreso date,
	@msj varchar(100) output
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Personal WHERE idPersonal = @idPersonal)
		BEGIN
			set @msj= 'PERSONAL NO EXISTE'
		END
	ELSE
		BEGIN
			UPDATE Personal 
			SET
				TipoDoc = @TipoDoc, 
				NumeroDoc = @NumeroDoc, 
				ApPaterno = @ApPaterno, 
				ApMaterno = @ApMaterno, 
				Nombre1 = @Nombre1, 
				Nombre2 = @Nombre2, 
				NombreCompleto = @NombreCompleto, 
				FechaNac = @FechaNac, 
				FechaIngreso = @FechaIngreso
			WHERE
				idPersonal = @idPersonal
	END
END
GO
