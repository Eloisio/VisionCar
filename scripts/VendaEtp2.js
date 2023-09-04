let list = [];
let selectedService = null;
window.onload = function () {
    getProjects();
}

function getProjects() {
    const cliente_EmpresaId = sessionStorage.getItem("cliente_EmpresaId");

    fetch("https://localhost:44321/api/Servico/Empresa/" + cliente_EmpresaId)
        .then(response => response.json())
        .then(response => {
            list = response;
            buildTable();
        })
}

function selectService(serviceId) {

    const selectedCard = document.querySelector(`[data-id="${serviceId}"]`);
    const priceElement = selectedCard.querySelector(".preco2");
    const preco = priceElement.textContent.replace("R$", "");
    const price = parseFloat(preco.replace("R$", ""));
    const desc = selectedCard.querySelector(".Descricao");
    const _desc = desc.textContent;

    if (selectedCard.classList.contains("selected")) {
        selectedCard.classList.remove("selected"); // Se estiver selecionado, remova a classe
        decrementservico(price, _desc);
    } else {
        selectedCard.classList.add("selected"); // Se não estiver selecionado, adicione a classe
        incrementservico(price, _desc);
    }
}

function buildTable() {
    document.querySelector("#table-body").innerHTML = '';
    const cliente_TpV = sessionStorage.getItem("cliente_tpveiculo");
    list.forEach(el => {
        var valor = cliente_TpV=="Grande"? el.precoGD: el.preco;
        let template = `
        <div class="row card" data-id="${el.id}" onclick="selectService(${el.id})">
        <div class="title-description style="flex-grow: 2;">
            <h6 class="Descricao" style="font-size: 16px;">${el.descricao}</h6> 
        </div>
        <div class="preco2" style="font-size: 16px;"> ${valor}</div>
    </div>
        `;
        document.querySelector("#table-body").insertAdjacentHTML("beforeend", template);
    });
}
let valorServicos = 0;
let valorCaixinha = 0;
let descricao = "";

function updateValores() {
    const valorTotal = valorServicos + valorCaixinha;
    document.getElementById("valor-servicos").textContent = `R$${valorServicos.toFixed(2)}`;
    document.getElementById("valor-caixinha").textContent = `R$${valorCaixinha.toFixed(2)}`;
    document.getElementById("valor-total").textContent = `R$${valorTotal.toFixed(2)}`;
    document.getElementById("descserv_").textContent = `${descricao}`;
}

function incrementservico(valor, desc) {
    valorServicos += valor;
    descricao += desc;
    updateValores();
}

function decrementservico(valor, desc) {
    valorServicos -= valor;
    descricao = descricao.replace(desc, "");
    updateValores();
}

function incrementCaixinha(valor) {
    valorCaixinha += valor;
    updateValores();
}

function decrementCaixinha(valor) {
    if (valorCaixinha >= valor) {
        valorCaixinha -= valor;
        updateValores();
    }
}
document.addEventListener("DOMContentLoaded", function () {
    const cliente_id = sessionStorage.getItem("cliente_id");
    const cliente_placa = sessionStorage.getItem("cliente_placa");
    const cliente_EmpresaId = sessionStorage.getItem("cliente_EmpresaId");


    document.getElementById("concluir-button").addEventListener("click", () => {
        // Obter o valor do elemento e converter para decimal
        const valorTotalText = document.getElementById("valor-total").textContent;
        const valorTotalDecimal = parseFloat(valorTotalText.replace("R$", "").replace(",", "."));
        const valorTotalcaixinha = document.getElementById("valor-caixinha").textContent;
        const valorTotalcaixinhaDecimal = parseFloat(valorTotalcaixinha.replace("R$", "").replace(",", "."));
        const dataAtual = new Date().toISOString();

        const radioDinheiro = document.querySelector('input[value="dinheiro"]');
        const radioCartao = document.querySelector('input[value="cartao"]');

        if (descricao != "" && (radioCartao.checked) || radioDinheiro.checked) {

            let payload = {
                "id": 0,
                "idEmpresa": cliente_EmpresaId,
                "idCliente": cliente_id, //pegar id cliente
                "valor": valorTotalDecimal,
                "caixinha": valorTotalcaixinhaDecimal,
                "inicio": dataAtual,
                "fim": dataAtual,
                "data": dataAtual,
                "pago": false,
                "avisarCliente": false,
                "excluido": false,
                "observacao": "",
                "descricao": descricao,
                "placa": cliente_placa,
                "tipoPgto": radioCartao.checked ? 2 : 1,
            }
            // Enviar para API
            fetch("https://localhost:44321/api/venda", {
                    method: 'POST',
                    body: JSON.stringify(payload),
                    headers: {
                        'Content-Type': 'application/json'
                    },
                })
                .then(response => response.text())
                .then(response => {
                    Swal.fire({
                        title: 'Bom Trabalho!',
                        text: "Aguarde em quanto deixamos seu veiculo Brilhando!!!",
                        icon: 'success',
                        confirmButtonText: 'Ok!'
                    })
                })
        } else {
            var msg = "Selecione um serviço!!!";
            if ((descricao != "") && (!radioCartao.checked && !radioDinheiro.checked)) {
                msg = "Selecione uma forma de Pagamento!!!";
            }
            Swal.fire({
                title: 'Ops!',
                text: msg,
                icon: 'alert',
                confirmButtonText: 'Ok!'
            })
        }
    });
});