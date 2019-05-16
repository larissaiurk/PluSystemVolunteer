
$(document).ready(function () {

    document.getElementById('error').style.display = "none";
    $("#cadastrarUsuario").submit(function (event) {

        var valid = true;
        if (document.getElementById("txtNome").value == ""){ valid = false; var msg = "Preencha o campo nome </br>"; }
        if (document.getElementById("txtEmail").value == ""){valid = false;  msg += "Preencha o campo de email </br>";  }
        if (document.getElementById("txtSenha").value == "") { valid = false; msg += "Preencha o campo de senha"; }

        //define a validação se for false ele interrompe o submit do form e mostra a classe de erro com os valores definidos acima

        if (valid == false) {
            document.getElementById('error').style.display = "block";
            document.getElementById('error').innerHTML = msg;
            event.preventDefault();
        }
    });


});