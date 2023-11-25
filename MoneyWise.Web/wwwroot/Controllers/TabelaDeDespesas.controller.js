sap.ui.define(
  [
    "./BaseController.controller",
    "sap/ui/model/json/JSONModel",
    "../services/Repositorio",
    "../model/Formatador",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "../services/MensagensDeTela"
  ],
  function (BaseController, JSONModel, Repositorio, Formatador, Filter, FilterOperator, MensagensDeTela) {
    "use strict";
    const caminhoControllerTabelaDePets = "sap.ui.moneywise.controller.TabelaDePets"
    return BaseController.extend(caminhoControllerTabelaDePets, {
      formatter: Formatador,
      onInit: function () {
        const rotaTabelaDePets = "tabelaDePets"
        var rota = this.getOwnerComponent().getRouter();
        rota.getRoute(rotaTabelaDePets).attachMatched(this._aoCoincidirRota, this);
      },
      _aoCoincidirRota: function () {
        this._processarEvento(() => {
          this.pegarDadosDaApi();
        })
      },
      pegarDadosDaApi: function () {
        var despesasModelo = new JSONModel();
        Repositorio.pegarDespesas()
          .then(dados => despesasModelo.setData({despesas: dados}))
          .catch((erro) => MensagensDeTela.sucesso(erro.message))
        this.getView().setModel(despesasModelo)
      },
      aoClicarBotaoAdicionar: function () {
        this._processarEvento(() => {
          const rotaCadastro = "cadastro";
          this.aoNavegar(rotaCadastro);
        })
      },
      aoPesquisar: function (evento) {
        this._processarEvento(() => {
          const query = "query"
          var aFiltro = [];
          var sQuery = evento.getParameter(query);
          if (sQuery) {
            aFiltro.push(
              new Filter("nome", FilterOperator.Contains, sQuery)
            );
          }
          const idPetsTable = "petsTable"
          const bindingItems = "items"
          var oTabela = this.byId(idPetsTable);
          var oBinding = oTabela.getBinding(bindingItems);
          oBinding.filter(aFiltro);
        })
      },
      aoClicarNoItem: function (evento) {
        this._processarEvento(() => {
          const rotaDetalhes = "detalhes"
          const idPropriedadeItem = "id"
          var idDoItem = evento.getSource().getBindingContext().getProperty(idPropriedadeItem);
          this.aoNavegar(rotaDetalhes, idDoItem)
        })
      },
    });
  }
);