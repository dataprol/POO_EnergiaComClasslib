namespace Energia1.domain
{
    public class Energia
    {
        public int id{ get; set; }
        public string cData{ get; set; }
        public int nLeitura{ get; set; }
        public int nKVMes{ get; set; }
        public float nValorPagar{ get; set; }
        public string cDataPago{ get; set; }
        public float nKVMedio{ get; set; }
        public Cliente cliente{ get; set; }
        public Energia(){}
        public Energia(int Id, string cData, int nLeitura, int nKVMes
        , float nValorPagar, string cDataPago, float nKVMedio)
        {
            this.id = Id;
            this.cData = cData;
            this.nLeitura = nLeitura;
            this.nKVMes = nKVMes;
            this.nValorPagar = nValorPagar;
            this.cDataPago = cDataPago;
            this.nKVMedio = nKVMedio;
        }        
    }
}