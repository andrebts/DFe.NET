﻿using System;
using System.Collections.Generic;
using System.Text;
using DFe.Utils;
using SMDFe.Tests.Entidades;

namespace SMDFe.Tests.Dao
{
    public class ConfiguracaoUtilsDao
    {
        private Configuracao _configuracao;
        private ConfiguracaoCertificado _configCertificado;

        public ConfiguracaoUtilsDao(Configuracao configuracao, ConfiguracaoCertificado configCertificado)
        {
            _configuracao = configuracao;
            _configCertificado = configCertificado;
        }

        public ConfiguracaoUtilsDao(Configuracao configuracao)
        {
            _configuracao = configuracao;
            _configCertificado = null;
        }

        public void setCongiguracoes()
        {
            if (_configuracao == null && _configCertificado == null)
                throw new NullReferenceException();

            Utils.Configuracoes.MDFeConfiguracao.ConfiguracaoCertificado = _configCertificado;

            Utils.Configuracoes.MDFeConfiguracao.CaminhoSchemas = _configuracao.ConfigWebService.CaminhoSchemas;
            Utils.Configuracoes.MDFeConfiguracao.CaminhoSalvarXml = _configuracao.DiretorioSalvarXml;
            Utils.Configuracoes.MDFeConfiguracao.IsSalvarXml = _configuracao.IsSalvarXml;

            Utils.Configuracoes.MDFeConfiguracao.VersaoWebService.VersaoLayout = _configuracao.ConfigWebService.VersaoLayout;

            Utils.Configuracoes.MDFeConfiguracao.VersaoWebService.TipoAmbiente = _configuracao.ConfigWebService.Ambiente;
            Utils.Configuracoes.MDFeConfiguracao.VersaoWebService.UfEmitente = _configuracao.ConfigWebService.UfEmitente;
            Utils.Configuracoes.MDFeConfiguracao.VersaoWebService.TimeOut = _configuracao.ConfigWebService.TimeOut;
        }
    }
}
