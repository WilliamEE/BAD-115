IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [EstadoDespacho] (
    [estadoDespachoId] int NOT NULL,
    [nombreEstado] varchar(200) NOT NULL,
    CONSTRAINT [PK_EstadoDespacho] PRIMARY KEY ([estadoDespachoId])
);
GO

CREATE TABLE [EstadoPedidos] (
    [estadoPedidoId] int NOT NULL,
    [nombreEstado] varchar(200) NOT NULL,
    CONSTRAINT [PK_EstadoPedidos] PRIMARY KEY ([estadoPedidoId])
);
GO

CREATE TABLE [Paises] (
    [paisId] int NOT NULL,
    [nombrepais] varchar(100) NOT NULL,
    CONSTRAINT [PK__Paises__45785B8B0CC32178] PRIMARY KEY ([paisId])
);
GO

CREATE TABLE [tiposProducto] (
    [tipoProductoId] int NOT NULL,
    [nombreTipo] varchar(200) NOT NULL,
    [visible] bit NOT NULL,
    CONSTRAINT [PK__tiposPro__0978E14E2B43D5C4] PRIMARY KEY ([tipoProductoId])
);
GO

CREATE TABLE [CentrosDistribucion] (
    [centroDistribucionId] int NOT NULL,
    [paisId] int NOT NULL,
    [nombreCentro] varchar(300) NOT NULL,
    [direccionCentro] varchar(500) NOT NULL,
    [visible] bit NOT NULL,
    CONSTRAINT [PK__CentrosD__B74C72AEF603E726] PRIMARY KEY ([centroDistribucionId]),
    CONSTRAINT [FK__CentrosDi__paisI__3C69FB99] FOREIGN KEY ([paisId]) REFERENCES [Paises] ([paisId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Clientes] (
    [clienteId] int NOT NULL,
    [paisId] int NOT NULL,
    [nombreCliente] varchar(300) NOT NULL,
    [apellidoCliente] varchar(300) NOT NULL,
    [correoCliente] varchar(300) NOT NULL,
    [telefonoCliente] varchar(25) NOT NULL,
    [direccionCliente] varchar(500) NOT NULL,
    [visible] bit NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([clienteId]),
    CONSTRAINT [FK__Clientes__paisId__398D8EEE] FOREIGN KEY ([paisId]) REFERENCES [Paises] ([paisId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ProveedoresTransporte] (
    [proveedorId] int NOT NULL,
    [paisId] int NOT NULL,
    [nombreProveedor] varchar(300) NOT NULL,
    [apellidoProveedor] varchar(300) NOT NULL,
    [correoProveedor] varchar(300) NOT NULL,
    [telefonoProveedor] varchar(25) NOT NULL,
    [direccionProveedor] varchar(500) NOT NULL,
    [visible] bit NOT NULL,
    CONSTRAINT [PK__Proveedo__8253255D2133A20A] PRIMARY KEY ([proveedorId]),
    CONSTRAINT [FK__Proveedor__paisI__52593CB8] FOREIGN KEY ([paisId]) REFERENCES [Paises] ([paisId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Producto] (
    [productoId] int NOT NULL,
    [tipoProductoId] int NOT NULL,
    [nombreProducto] varchar(200) NOT NULL,
    [codigoBarra] varchar(200) NOT NULL,
    [visible] bit NOT NULL,
    CONSTRAINT [PK_Producto] PRIMARY KEY ([productoId]),
    CONSTRAINT [FK__Producto__tipoPr__412EB0B6] FOREIGN KEY ([tipoProductoId]) REFERENCES [tiposProducto] ([tipoProductoId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Pedidos] (
    [pedidoId] int NOT NULL,
    [estadoPedidoId] int NOT NULL,
    [clienteId] int NOT NULL,
    [direccionEntrega] varchar(500) NOT NULL,
    [observacionesAdicionales] varchar(500) NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([pedidoId]),
    CONSTRAINT [FK__Pedidos__cliente__47DBAE45] FOREIGN KEY ([clienteId]) REFERENCES [Clientes] ([clienteId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Iventario] (
    [inventarioId] int NOT NULL,
    [centroDistribucionId] int NOT NULL,
    [productoId] int NOT NULL,
    [entrada] int NOT NULL,
    [salida] int NOT NULL,
    CONSTRAINT [PK__Iventari__23747585FFBA487B] PRIMARY KEY ([inventarioId]),
    CONSTRAINT [FK__Iventario__centr__440B1D61] FOREIGN KEY ([centroDistribucionId]) REFERENCES [CentrosDistribucion] ([centroDistribucionId]) ON DELETE NO ACTION,
    CONSTRAINT [FK__Iventario__produ__44FF419A] FOREIGN KEY ([productoId]) REFERENCES [Producto] ([productoId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Despachos] (
    [despachoId] int NOT NULL,
    [pedidoId] int NOT NULL,
    [proveedorId] int NOT NULL,
    [estadoDespachoId] int NOT NULL,
    [observacionesAdicionales] varchar(500) NULL,
    [fechaEntrega] datetime NOT NULL,
    CONSTRAINT [PK_Despachos] PRIMARY KEY ([despachoId]),
    CONSTRAINT [FK__Despachos__estad__571DF1D5] FOREIGN KEY ([estadoDespachoId]) REFERENCES [EstadoDespacho] ([estadoDespachoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK__Despachos__pedid__5535A963] FOREIGN KEY ([pedidoId]) REFERENCES [Pedidos] ([pedidoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK__Despachos__prove__5629CD9C] FOREIGN KEY ([proveedorId]) REFERENCES [ProveedoresTransporte] ([proveedorId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [DetallePedidos] (
    [detallePedidoId] int NOT NULL,
    [pedidoId] int NOT NULL,
    [productoId] int NOT NULL,
    [cantidad] int NOT NULL,
    CONSTRAINT [PK_DetallePedidos] PRIMARY KEY ([detallePedidoId]),
    CONSTRAINT [FK__DetallePe__pedid__4CA06362] FOREIGN KEY ([pedidoId]) REFERENCES [Pedidos] ([pedidoId]) ON DELETE NO ACTION,
    CONSTRAINT [FK__DetallePe__produ__4D94879B] FOREIGN KEY ([productoId]) REFERENCES [Producto] ([productoId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [ConfirmacionRecepcion] (
    [confirmacionRecepcionId] int NOT NULL,
    [despachoId] int NOT NULL,
    [clienteId] int NOT NULL,
    [entregado] bit NOT NULL,
    CONSTRAINT [PK_ConfirmacionRecepcion] PRIMARY KEY ([confirmacionRecepcionId]),
    CONSTRAINT [FK__Confirmac__clien__5AEE82B9] FOREIGN KEY ([clienteId]) REFERENCES [Clientes] ([clienteId]) ON DELETE NO ACTION,
    CONSTRAINT [FK__Confirmac__despa__59FA5E80] FOREIGN KEY ([despachoId]) REFERENCES [Despachos] ([despachoId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_CentrosDistribucion_paisId] ON [CentrosDistribucion] ([paisId]);
GO

CREATE INDEX [IX_Clientes_paisId] ON [Clientes] ([paisId]);
GO

CREATE INDEX [IX_ConfirmacionRecepcion_clienteId] ON [ConfirmacionRecepcion] ([clienteId]);
GO

CREATE INDEX [IX_ConfirmacionRecepcion_despachoId] ON [ConfirmacionRecepcion] ([despachoId]);
GO

CREATE INDEX [IX_Despachos_estadoDespachoId] ON [Despachos] ([estadoDespachoId]);
GO

CREATE INDEX [IX_Despachos_pedidoId] ON [Despachos] ([pedidoId]);
GO

CREATE INDEX [IX_Despachos_proveedorId] ON [Despachos] ([proveedorId]);
GO

CREATE INDEX [IX_DetallePedidos_pedidoId] ON [DetallePedidos] ([pedidoId]);
GO

CREATE INDEX [IX_DetallePedidos_productoId] ON [DetallePedidos] ([productoId]);
GO

CREATE INDEX [IX_Iventario_centroDistribucionId] ON [Iventario] ([centroDistribucionId]);
GO

CREATE INDEX [IX_Iventario_productoId] ON [Iventario] ([productoId]);
GO

CREATE INDEX [IX_Pedidos_clienteId] ON [Pedidos] ([clienteId]);
GO

CREATE INDEX [IX_Producto_tipoProductoId] ON [Producto] ([tipoProductoId]);
GO

CREATE INDEX [IX_ProveedoresTransporte_paisId] ON [ProveedoresTransporte] ([paisId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230524001017_Initial Migration', N'5.0.17');
GO

COMMIT;
GO

