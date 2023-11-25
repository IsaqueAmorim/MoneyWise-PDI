sap.ui.define([
], function () {
  "use strict";
  return {
    _urlBase: "/api",

    _mandarRequisicao: function (urlDoMetodo, opcoesDoMetodo) {
      const statusNaoEncontrado = 404;
      const statusSemConteudo = 204;
      const textoErroAoCadastrar = "textoErroAoCadastrar"
      var urlInteira = this._urlBase + urlDoMetodo;
      return fetch(urlInteira, opcoesDoMetodo).then((resposta) => {
        if (resposta.status === statusNaoEncontrado) {
          return false
        }
        if (!resposta.ok) {
          throw new Error(i18n.getText(textoErroAoCadastrar));
        } else if (resposta.status === statusSemConteudo) {
          return {};
        } else {
          return resposta.json();
        }
      });
    },

    _get: function (endpoint) {
      return this._mandarRequisicao(endpoint, { method: "GET" });
    },

    _post: function (endpoint, dadosDespesa) {
      return this._mandarRequisicao(endpoint, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(dadosDespesa),
      });
    },

    _put: function (endpoint, dadosDespesa) {
      return this._mandarRequisicao(endpoint, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(dadosDespesa),
      });
    },

    _delete: function (endpoint) {
      return this._mandarRequisicao(endpoint, { method: "DELETE" });
    },

    pegarDespesas: function () {
      return this._get("/despesas");
    },

    pegarDespesaPeloId: function (id) {
      return this._get("/despesas/" + id);
    },

    criarDespesa: function (Despesa) {
      return this._post("/despesas", Despesa);
    },

    editarDespesa: function (id, Despesa) {
      return this._put("/despesas/" + id, Despesa);
    },

    deletarDespesa: function (id) {
      return this._delete("/despesas/" + id);
    },
  };
});