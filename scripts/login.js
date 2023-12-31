const init = () => {
    const validateEmail = (event) => {
        const input = event.currentTarget;
        const regex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        const emailTest = regex.test(input.value);

        if (!emailTest) {
            submitButton.setAttribute("disabled", "disabled");
            input.nextElementSibling.classList.add('error');
        } else {
            submitButton.removeAttribute("disabled");
            input.nextElementSibling.classList.remove('error');
        }
    }

    const validatePassowrd = (event) => {
        const input = event.currentTarget;

        if (input.value.length < 4) {
            submitButton.setAttribute("disabled", "disabled");
            input.nextElementSibling.classList.add('error');
        } else {
            submitButton.removeAttribute("disabled");
            input.nextElementSibling.classList.remove('error');
        }
    }

    const inputEmail = document.querySelector('input[type="email"]');
    const inputPassword = document.querySelector('input[type="password"]');
    const submitButton = document.querySelector('.login__submit');

    inputEmail.addEventListener('input', validateEmail);
    inputPassword.addEventListener('input', validatePassowrd);

    const errorHandler = () => {
        submitButton.classList.remove('loading');
        submitButton.classList.remove('success');
        submitButton.classList.add('error');
        submitButton.textContent = "Error :(";
    }

    const successHandler = () => {
        submitButton.classList.remove('loading');
        submitButton.classList.remove('error');
        submitButton.classList.add('success');
        submitButton.textContent = "Sent! :)";
    }

    if (submitButton) {

        submitButton.addEventListener('click', (event) => {
            event.preventDefault();

            submitButton.textContent = "Loading...";

            fetch("https://localhost:44321/api/users/login/" + inputEmail.value)
                .then(response => response.json())
                .then(response => {
                    if (inputPassword.value === response.senha) {
                        sessionStorage.setItem("User_id", response.id);
                        sessionStorage.setItem("User_idEmpresa", response.idEmpresa);
                        sessionStorage.setItem("User_nome", response.nome);
                        sessionStorage.setItem("User_email", response.email);
                        sessionStorage.setItem("User_Master", response.master);

                        window.location.href = "Menu.html";
                    } else {
                        const msgElement = document.getElementById("msg");
                        msgElement.textContent = "Usuario não Cadastrado";
                        console.log("senha errada");
                    }

                })
        })
    }
}

window.onload = init;