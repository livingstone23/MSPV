namespace PVM.Services.Gestpro.Model.Dto
{
    public class ClientDto
    {
        public int IdCli { get; set; }

        public string RaoSocial { get; set; }

        public String Cognom1 { get; set; }

        public String Cognom2 { get; set; }

        public int? CodiFact { get; set; }


        public string CIF { get; set; }
        public string Adr { get; set; }
        public string CP { get; set; }
        public int? IdProv { get; set; }
        public int? IdPob { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string PersonaCte { get; set; }
        public string ValorIdioma { get; set; }


        public int? IdFormaP { get; set; }
        public string NCEntitat { get; set; }
        public string NCOficina { get; set; }
        public string NCDC { get; set; }
        public string NCCompte { get; set; }
        public int? ValorPeriodFact { get; set; }
        public int? ValorIntFormatFactura { get; set; }
        public short? swIRPF { get; set; }
        public short? swCobrarFoto { get; set; }
        public short? swComandaUnica { get; set; }
        public short? swFactSoli { get; set; }
        public short? swLlistaPrevi { get; set; }
        public short? swVerificarInf { get; set; }
        public short? swSegonaFact { get; set; }
        public short? swN19 { get; set; }
        public int? IdEmpAux { get; set; }
        public short? swCopiar { get; set; }
        public int? ValorFormatCopia { get; set; }
        public short? PlacDies { get; set; }
        public short? PlacDiesUrgent { get; set; }




    }
}
