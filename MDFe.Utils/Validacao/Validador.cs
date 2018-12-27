/********************************************************************************/
/* Projeto: Biblioteca ZeusMDFe                                                 */
/* Biblioteca C# para emissão de Manifesto Eletrônico Fiscal de Documentos      */
/* (https://mdfe-portal.sefaz.rs.gov.br/                                        */
/*                                                                              */
/* Direitos Autorais Reservados (c) 2014 Adenilton Batista da Silva             */
/*                                       Zeusdev Tecnologia LTDA ME             */
/*                                                                              */
/*  Você pode obter a última versão desse arquivo no GitHub                     */
/* localizado em https://github.com/adeniltonbs/Zeus.Net.NFe.NFCe               */
/*                                                                              */
/*                                                                              */
/*  Esta biblioteca é software livre; você pode redistribuí-la e/ou modificá-la */
/* sob os termos da Licença Pública Geral Menor do GNU conforme publicada pela  */
/* Free Software Foundation; tanto a versão 2.1 da Licença, ou (a seu critério) */
/* qualquer versão posterior.                                                   */
/*                                                                              */
/*  Esta biblioteca é distribuída na expectativa de que seja útil, porém, SEM   */
/* NENHUMA GARANTIA; nem mesmo a garantia implícita de COMERCIABILIDADE OU      */
/* ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA. Consulte a Licença Pública Geral Menor*/
/* do GNU para mais detalhes. (Arquivo LICENÇA.TXT ou LICENSE.TXT)              */
/*                                                                              */
/*  Você deve ter recebido uma cópia da Licença Pública Geral Menor do GNU junto*/
/* com esta biblioteca; se não, escreva para a Free Software Foundation, Inc.,  */
/* no endereço 59 Temple Street, Suite 330, Boston, MA 02111-1307 USA.          */
/* Você também pode obter uma copia da licença em:                              */
/* http://www.opensource.org/licenses/lgpl-license.php                          */
/*                                                                              */
/* Zeusdev Tecnologia LTDA ME - adenilton@zeusautomacao.com.br                  */
/* http://www.zeusautomacao.com.br/                                             */
/* Rua Comendador Francisco josé da Cunha, 111 - Itabaiana - SE - 49500-000     */
/********************************************************************************/

using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using MDFe.Utils.Configuracoes;
using MDFe.Utils.Flags;

namespace MDFe.Utils.Validacao
{
    public class Validador
    {
        private static string ObterNomeSchema(MDFeServico mdFeServico, VersaoServico versao)
        {
            switch (mdFeServico)
            {
                case MDFeServico.MDFEletronico:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "MDFe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "MDFe_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeRodo:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "MDFeModalRodoviario_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "MDFeModalRodoviario_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeAereo:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "MDFeModalAereo_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "MDFeModalAereo_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeAquav:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "MDFeModalAquaviario_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "MDFeModalAquaviario_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeFerrov:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "MDFeModalFerroviario_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "MDFeModalFerroviario_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeConsReciMDFe:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "consReciMdfe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "consReciMdfe_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeConsSitMDFe:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "consSitMdfe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "consSitMdfe_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeConsStatServMDFe:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "consStatServMDFe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "consStatServMDFe_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeCosMDFeNaoEnc:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "consMDFeNaoEnc_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "consMDFeNaoEnc_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeEnviMDFe:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "enviMDFe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "enviMDFe_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeEventoMDFe:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "eventoMDFe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "eventoMDFe_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeEvCancMDFe:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "evCancMDFe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "evCancMDFe_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeEvEncMDFe:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "evEncMDFe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "evEncMDFe_v3.00.xsd";
                    }
                    break;
                case MDFeServico.MDFeEvIncCondutorMDFe:
                    switch (versao)
                    {
                        case VersaoServico.Versao100:
                            return "evIncCondutorMDFe_v1.00.xsd";
                        case VersaoServico.Versao300:
                            return "evIncCondutorMDFe_v3.00.xsd";
                    }
                    break;
            }
            return null;
        }

        public static void Valida(string xml, MDFeServico servico, MDFeConfiguracao cfgMdfe = null)
        {
            var schema = ObterNomeSchema(servico, cfgMdfe.VersaoWebService.VersaoLayout);
            Valida(xml, schema, cfgMdfe);
        }

        public static void Valida(string xml, string schema, MDFeConfiguracao cfgMdfe = null)
        {
            var config = cfgMdfe ?? MDFeConfiguracao.Instancia;
            var pathSchema = config.CaminhoSchemas;
            
            if (!Directory.Exists(pathSchema))
                throw new Exception("Diretório de Schemas não encontrado: \n" + pathSchema);

            var arquivoSchema = pathSchema + @"\" + schema;

            // Define o tipo de validação
            var cfg = new XmlReaderSettings { ValidationType = ValidationType.Schema };

            // Carrega o arquivo de esquema
            var schemas = new XmlSchemaSet();
            // Adiciona o XmlResolver
            schemas.XmlResolver = new XmlUrlResolver();
            cfg.Schemas = schemas;
            // Quando carregar o eschema, especificar o namespace que ele valida
            // e a localização do arquivo 
            schemas.Add(null, arquivoSchema);
            // Especifica o tratamento de evento para os erros de validacao
            cfg.ValidationEventHandler += ValidationEventHandler;
            var resolver = new XmlUrlResolver();

            // cria um leitor para validação
            var validator = XmlReader.Create(new StringReader(xml), cfg);
            try
            {
                // Faz a leitura de todos os dados XML
                while (validator.Read())
                {
                }
            }
            catch (XmlException err)
            {
                // Um erro ocorre se o documento XML inclui caracteres ilegais
                // ou tags que não estão aninhadas corretamente
                throw new Exception("Ocorreu o seguinte erro durante a validação XML:" + "\n" + err.Message);
            }
            finally
            {
                validator.Close();
            }
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw new Exception("Erros da validação : " + e.Message);
        }
    }
}