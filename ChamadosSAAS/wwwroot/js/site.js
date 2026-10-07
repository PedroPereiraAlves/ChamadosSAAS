document.addEventListener("DOMContentLoaded", () => {
  document.querySelectorAll("[data-password-toggle]").forEach((button) => {
    const inputId = button.getAttribute("aria-controls");
    const input = inputId
      ? document.getElementById(inputId)
      : button.parentElement?.querySelector("input");

    if (!(input instanceof HTMLInputElement)) {
      return;
    }

    button.addEventListener("click", () => {
      const willShow = input.type === "password";
      input.type = willShow ? "text" : "password";
      button.textContent = willShow ? "Ocultar" : "Mostrar";
      button.setAttribute("aria-label", willShow ? "Ocultar senha" : "Mostrar senha");
      button.setAttribute("aria-pressed", willShow ? "true" : "false");
    });
  });

  const status = document.querySelector(".form-status");
  if (status instanceof HTMLElement) {
    status.focus();
    return;
  }

  const firstInvalid = document.querySelector(".input-validation-error");
  if (firstInvalid instanceof HTMLElement) {
    firstInvalid.focus();
  }
});
