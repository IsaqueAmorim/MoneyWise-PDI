sap.ui.define(
  [
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "../services/MensagensDeTela"
  ],
  function (Controller, History, MensagensDeTela) {
    "use strict";
    const caminhoBaseController = "sap.ui.moneywise.controller.BaseController"

    return Controller.extend(caminhoBaseController, {
      aoClicarEmVoltar: function (nomeRota, id = null) {
        this._processarEvento(() => {
          var historico = History.getInstance();
          var hashAnterior = historico.getPreviousHash();
          if (hashAnterior !== undefined) {
            window.history.go(-1);
          } else {
            this.aoNavegar(nomeRota, id);
          }
        })
      },
      _processarEvento: function (action) {
        const tipoDaPromise = "catch",
          tipoBuscado = "function";
        try {
          var promise = action();
          if (promise && typeof promise[tipoDaPromise] == tipoBuscado) {
            promise.catch((error) => MensagensDeTela.erro(error.message));
          }
        } catch (error) {
          MensagensDeTela.erro(error.message);
        }
      },
      aoNavegar: function (nomeRota, id) {
        var rota = this.getOwnerComponent().getRouter();
        if (id) {
          rota.navTo(nomeRota, { id });
        }
        rota.navTo(nomeRota);
      },
    });
  }
);