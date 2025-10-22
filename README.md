# Sistema de Gestión de Insumos, Recetas y Pedidos

## Descripción
Este proyecto es un sistema de gestión que permite administrar insumos, recetas y pedidos, con registro de proveedores e integración con **SQL Server** para persistencia de datos.  
Está orientado a empresas que producen a partir de insumos básicos y necesitan organizar su flujo de trabajo desde la materia prima hasta el envío de pedidos.

## Funcionalidades
- **Proveedores**:
  - Los proveedores pueden registrarse en el sistema.
  - Pueden consultar qué insumos proveen.

- **Empleados**:
  - Registran manualmente los insumos en el sistema (nombre, cantidad, unidad, precio, etc.).
  - Administran recetas, definiendo las proporciones y cantidades de cada insumo.

- **Recetas**:
  - Cada receta se compone de distintos insumos con cantidades específicas.
  - El sistema ajusta automáticamente las cantidades de insumos según la cantidad solicitada en un pedido.

- **Pedidos**:
  - Registro de pedidos con fecha, cliente, receta solicitada y cantidad.
  - Cálculo automático de los insumos necesarios para cumplir el pedido.
  - Registro del estado del pedido (**pendiente, enviado, completado**).

- **Persistencia**:
  - Toda la información se almacena en **SQL Server**.

## Tecnologías
- **Lenguaje**: C#  
- **Framework**: .NET framework (Windows Forms)  
- **Base de Datos**: SQL Server  
