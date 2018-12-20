using MDFe.Servicos.Factory;
using MDFe.Tests.Dao;
using MDFe.Tests.Entidades;
using MDFe.Wsdl.Gerado.MDFeConsultaNaoEncerrados;
using MDFe.Wsdl.Gerado.MDFeConsultaProtoloco;
using MDFe.Wsdl.Gerado.MDFeEventos;
using MDFe.Wsdl.Gerado.MDFeRecepcao;
using MDFe.Wsdl.Gerado.MDFeRetRecepcao;
using MDFe.Wsdl.Gerado.MDFeStatusServico;
using Xunit;

namespace MDFe.Tests.ServicosTests
{
    
    public class WsdlFactoryTests
    {
        #region Variáveis

        private readonly Configuracao _configuracao;

        #endregion

        #region Setup

        
        public WsdlFactoryTests()
        {
            var configuracaoDao = new ConfiguracaoDao();
            _configuracao = configuracaoDao.GetConfiguracao();

            var configcertificado = new CertificadoDao().getConfiguracaoCertificado();

            var configuracoes = new ConfiguracaoUtilsDao(_configuracao, configcertificado);
            configuracoes.setCongiguracoes();
        }

        #endregion

        #region Testes para a classe WsdlFactory

        [Fact]
        public void Deve_Testar_A_Criacao_Do_Metodo_CriaWsdlMDFeConsNaoEnc()
        {
            //Arrange

            //Act
            var consultaWsdl = WsdlFactory.CriaWsdlMDFeConsNaoEnc();

            //Assert
            Assert.NotNull(consultaWsdl);
            Assert.IsType<MDFeConsNaoEnc>(consultaWsdl);
        }

        
        [Fact]
        public void Deve_Testar_A_Criacao_Do_Metodo_CriaWsdlMDFeConsulta()
        {
            //Arrange

            //Act
            var consultaWsdl = WsdlFactory.CriaWsdlMDFeConsulta();

            //Assert
            Assert.NotNull(consultaWsdl);
            Assert.IsType<MDFeConsulta>(consultaWsdl);
        }

        [Fact]
        public void Deve_Testar_A_Criacao_Do_Metodo_CriaWsdlMDFeRecepcaoEvento()
        {
            //Arrange

            //Act
            var consultaWsdl = WsdlFactory.CriaWsdlMDFeRecepcaoEvento();

            //Assert
            Assert.NotNull(consultaWsdl);
            Assert.IsType<MDFeRecepcaoEvento>(consultaWsdl);
        }

        
        [Fact]
        public void Deve_Testar_A_Criacao_Do_Metodo_CriaWsdlMDFeRecepcao()
        {
            //Arrange

            //Act
            var consultaWsdl = WsdlFactory.CriaWsdlMDFeRecepcao();

            //Assert
            Assert.NotNull(consultaWsdl);
            Assert.IsType<MDFeRecepcao>(consultaWsdl);
        }

        [Fact]
        public void Deve_Testar_A_Criacao_Do_Metodo_CriaWsdlMDFeRetRecepcao()
        {
            //Arrange

            //Act
            var consultaWsdl = WsdlFactory.CriaWsdlMDFeRetRecepcao();

            //Assert
            Assert.NotNull(consultaWsdl);
            Assert.IsType<MDFeRetRecepcao>(consultaWsdl);
        }


        [Fact]
        public void Deve_Testar_A_Criacao_Do_Metodo_CriaWsdlMDFeStatusServico()
        {
            //Arrange

            //Act
            var consultaWsdl = WsdlFactory.CriaWsdlMDFeStatusServico();

            //Assert
            Assert.NotNull(consultaWsdl);
            Assert.IsType<MDFeStatusServico>(consultaWsdl);
        }

        #endregion
    }
}
