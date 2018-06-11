CREATE TABLE [dbo].[T_EquipeAdverse] (
    [IdEquipeVisiteuse]       INT           IDENTITY (1, 1) NOT NULL,
    [NonEquipeVisiteuse]      NVARCHAR (50) NOT NULL,
    [LocationEquipeVisiteuse] NVARCHAR (50) NOT NULL,
    [IdClubAdverse]         INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEquipeVisiteuse] ASC)
);

