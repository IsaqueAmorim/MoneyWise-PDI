sap.ui.define([
], function () {
  "use strict";

	return {
		iconesTipoDespesa: function (tipoDespesa) {
			switch (tipoDespesa) {
				case "EDUCACAO":
					return "../assets/icons-images/educacao.png";
				case "ALIMENTACAO":
					return "../assets/icons-images/alimentacao.png";
				case "SAUDE":
					return "../assets/icons-images/saude.png";
				case "PETS":
					return "../assets/icons-images/pets.png";
				default:
					return tipoDespesa;
			}
		}
	};
});