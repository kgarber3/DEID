drop table if exists [dbo].[biml_deid_databases]
create table [dbo].[biml_deid_databases] (
    [id] int identity not null
    , [database_name] sysname not null
    , [source_sql_instance] varchar(50) not null
    , [connection_string] varchar(500) not null
    , [enabled] bit not null default 1
    , constraint pk_biml_deid_databases primary key clustered ([id])
) 

drop table if exists [dbo].[biml_deid_tables]
create table [dbo].[biml_deid_tables] (
    [id] int identity not null
    , [biml_deid_databases_id] int not null
    , [table_name] sysname not null
    , [override_query] varchar(max) null
    , [biml_design_pattern] int not null default 1
    , [is_temporal] bit not null default 0
    , [enabled] bit not null default 1
    , constraint pk_biml_deid_tables primary key clustered ([id])
    , constraint fk_biml_deid_databases foreign key ([biml_deid_databases_id]) references [dbo].[biml_deid_databases] ([id])
)

drop table if exists [dbo].[biml_deid_columns] 
create table [dbo].[biml_deid_columns] (
    [id] int identity not null
    , [biml_deid_tables_id] int not null
    , [column_name] sysname not null
    , [data_type_full] varchar(150) not null
    , [data_type] varchar(150) not null
    , [data_length] varchar(15) null
    , [cipher] varchar(5)
    , [enabled] bit not null default 0
    , constraint pk_biml_deid_columns primary key clustered ([id])
    , constraint fk_biml_deid_tables foreign key ([biml_deid_tables_id]) references [dbo].[biml_deid_tables] ([id])
)
