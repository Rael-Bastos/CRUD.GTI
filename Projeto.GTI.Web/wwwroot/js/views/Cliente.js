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
    Salvar: function () {
        this.PreencherObjeto();
        if (!this.ValidaObjeto()) return;
        console.log(JSON.stringify(this));
        $.ajax({
            type: "POST",
            url: context + 'Clientes/Inserir',
            dataType: 'json',
            ascync: true,
            contentType: 'application/json',
            data: JSON.stringify(this),
            success: function (data) {
                window.location.href = context + "Clientes/Index";
            },
            error: function (xhr, error) {
                console.log(xhr)
                alert(error)
            }
        });
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
                window.location.href = context + "Clientes/Index";
            },
            error: function (xhr, error) {
                console.log(xhr)
                console.log(error)
                alert(error)
            }
        });
    },
    TelaListagem: function () {
        window.location.href = context + "Clientes/Index";
    }
}