using System.ComponentModel;

namespace PVM.Services.Gestpro.Model
{


    public enum OrigenETramitacio
    {
        [Description("Aplicación GestPro")]
        EPGest = 0,
        [Description("TelemáticaWeb")]
        Web = 1,
        [Description("ArchivoTxt")]
        Txt = 2,
        [Description("ArchivoXML")]
        Xml = 3,
        [Description("WebCSV")]
        CSV = 4
    }

    public enum TipusETramitacio
    {
        [Description("Leasing")]
        Leasing = 0,
        [Description("Renting")]
        Renting = 1,
        [Description("Financiacion")]
        Financiacion = 2,

    }



    public enum FirmaETramitacio
    {
        [Description("Manuscrita")]
        Manuscrita = 0,
        [Description("Electrónica")]
        Electronica = 1,
        [Description("Firma OTP")]
        FirmaOTP = 2,

    }



}
