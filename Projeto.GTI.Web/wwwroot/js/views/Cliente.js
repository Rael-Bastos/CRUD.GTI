var Cliente = function () {
    this.codCliente = 0
    this.cpf = ''
    this.nome = ''
    this.rg = ''
    this.dataExpedicao = ''
    this.orgaoExpedicao = ''
    this.ufExpedicao = ''
    this.dataNascimento = ''
    this.sexo = ''
    this.estadoCivil = ''
    this.cep = ''
    this.logradouro = ''
    this.numero = ''
    this.complemento = ''
    this.bairro = ''
    this.cidade = ''
    this.uf = ''
}

Cliente.prototype = {
    constructor: Cliente,
    PreencherObjeto: function () {
        this.codCliente = 0
        this.cpf = $("#Cpf").val();
        this.nome = $("#Nome").val();
        this.rg = $("#Rg").val();
        this.dataExpedicao = $("#dtExpedicao").val();
        this.orgaoExpedicao = $("#inputEstado").val();
        this.ufExpedicao = $("#inputUfEx").val();
        this.dataNascimento = $("#dtNascimento").val();
        this.sexo = $("#inputSexo").val();
        this.estadoCivil = $("#inputEstadoCivil").val();
        this.cep = $("#cep").val();
        this.logradouro = $("#logradouro").val();
        this.numero = $("#nr").val();
        this.complemento = $("#complemento").val();
        this.bairro = $("#bairro").val();
        this.cidade = $("#cidade").val();
        this.uf = $("#inputUf").val();

    },
    Pesquisar: function () {
        var nome = $("#nomeCorretorPesquisa").val();
        var tipoRegistro = $("#TipoRegistro").val();
        var idDivCombo = "#div-sel-corretor";
        var classForm = ".resultado2";

        if ($.trim(nome).length < 3) {
            swt.AlertaErro("", "Digite no mínimo 3 letras na pesquisa.");
            $("#nomeCorretorPesquisa").focus();
            return;
        }

        $(idDivCombo).hide();

        this.LimparCombo();
        usuario.Limpar();
        $(classForm).hide();

        ToggleLoad();

        $.ajax({
            type: "get",
            url: "ConsultarCorretorPorNome?nome=" + nome + "&tipoRegistro=" + tipoRegistro,
            contentType: "application/json",
            success: function (result) {
                ToggleLoad();

                if (result.IsOk) {
                    var corretor = result.ObjetoRetorno;
                    var style = "";
                    var msg = "";
                    var id = "";
                    var filial = "";
                    var idCombo = "#selCorretor";
                    var isUser = false;

                    if (corretor.length > 0) {
                        $(idCombo).append($("<option>").val("-1").text("Selecione..."));

                        corretor.forEach(function (e, i) {
                            if (e.IdUsuario > 0 && e.CdTipoRegistroERP == 1) {
                                msg = "Corretor já cadastrado - ";
                                id = e.IdUsuario;
                                isUser = true;
                            }
                            else if (e.IdUsuario > 0 && (e.CdTipoRegistroERP == 2 || e.CdTipoRegistroERP == 6)) {
                                msg = "Assessoria já cadastrada - ";
                                id = e.IdUsuario;
                                isUser = true;
                            }
                            else if (e.IdUsuario > 0) {
                                msg = "Usuário já cadastrado - ";
                                id = e.IdUsuario;
                                isUser = true;
                            }
                            else if (e.CdTipoRegistroERP == 2 || e.CdTipoRegistroERP == 6) {
                                msg = "Assessoria - ";
                                id = e.IdPessoaERP;
                                isUser = false;
                            }
                            else if (e.CdTipoRegistroERP == 1) {
                                msg = "Corretor - ";
                                id = e.IdPessoaERP;
                                isUser = false;
                            }
                            else {
                                msg = "";
                                id = "";
                                isUser = false;
                            }

                            style = isUser ? "color: red" : "";

                            if (id != "") {
                                if (filial != e.CdFilial) {
                                    filial = e.CdFilial;

                                    $(idCombo).append($("<optgroup label='Filial - " + filial + "'>"));
                                }

                                $(idCombo).append($("<option style='" + style + "' data-login='" + e.NomeUsuario + "' data-nome='" + e.Nome + "' data-email='" + e.Email + "' data-cd-filial='" + e.CdFilial + "' data-is-user='" + isUser + "'>").val(id).text(msg + e.Nome));
                            }
                        });
                    }
                    else {
                        $(idCombo).append($("<option>").val("-1").text("Nenhum registro encontrado."));
                    }

                    $(idDivCombo).show();
                }
                else {
                    swt.AlertaErro("Erro", result.MensagemRetorno);
                }
            },
            error: function (xhr) {
                ToggleLoad();
                console.log(xhr);
                swt.AlertaErro("Erro", xhr.responseText);
            }
        });
    },
    ValidaObjeto: function () {
        if (this.cpf.length == 0 || this.nome.length == 0 || this.dataNascimento.length == 0 || this.sexo == 'Escolher...' ||
            this.estadoCivil == 'Escolher...' || this.cep.length == 0 ||
            this.logradouro.length == 0 || this.numero.length == 0 || this.bairro.length == 0 || this.cidade.length == 0 ) {
            $(".alert").addClass('show');
            return false;
        }
        else {
            $(".alert").removeClass('show');
            $(".alert").addClass('hide');
            return true;
        }
    },
    Alterar: function () {
        this.PreencherObjeto();
        if (!this.ValidaObjeto()) return;
        console.log(JSON.stringify(this));
        $.ajax({
            type: "POST",
            url: context + 'Clientes/Alterar',
            dataType: 'json',
            ascync: true,
            contentType: 'application/json',
            data: JSON.stringify(this),
            success: function (data) {
                alert("FOII")
            },
            error: function (xhr, error) {
                console.log(xhr)
            }
        });
    },
    TelaListagem: function () {
        window.location.href = context + "Clientes/Index";
    },
    LimparCombo: function () {
        //$("#selCorretor").html("");
        $("#selCorretor").val('');
    },

    LimparPesquisa: function () {
        $("#TipoRegistro").val("");
        $("#nomeCorretorPesquisa").val("");
        $("#selCorretor").html("");
    }
}