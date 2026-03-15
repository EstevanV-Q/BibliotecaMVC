-- =============================================
-- Script para crear la base de datos y tabla
-- Proyecto: BibliotecaMVC
-- Base de datos: caldosacr
-- =============================================

-- 1. Crear la base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'caldosacr')
BEGIN
    CREATE DATABASE caldosacr;
END
GO

USE caldosacr;
GO

-- 2. Crear la tabla Libro
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Libro]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Libro] (
        [Codigo]           NVARCHAR(10)  NOT NULL,
        [Titulo]           NVARCHAR(MAX) NOT NULL,
        [Autor]            NVARCHAR(MAX) NOT NULL,
        [FechaPublicacion] DATETIME      NOT NULL,
        CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED ([Codigo] ASC)
    );

    -- 3. Insertar datos iniciales (opcional)
    INSERT INTO [dbo].[Libro] ([Codigo], [Titulo], [Autor], [FechaPublicacion])
    VALUES 
    ('L001', 'El Quijote', 'Miguel de Cervantes', '1605-01-16'),
    ('L002', 'Cien años de soledad', 'Gabriel García Márquez', '1967-05-30'),
    ('L003', '1984', 'George Orwell', '1949-06-08');

    PRINT 'Tabla Libro creada y datos iniciales insertados.';
END
ELSE
BEGIN
    PRINT 'La tabla Libro ya existe.';
END
GO
