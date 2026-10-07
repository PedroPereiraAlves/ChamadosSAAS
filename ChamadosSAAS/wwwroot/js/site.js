if (window.jQuery?.validator?.unobtrusive) {
  window.jQuery.validator.unobtrusive.options = {
    invalidHandler: function (_event, validator) {
      const invalidNames = new Set(
        (validator.errorList || []).map((item) => item.element?.name).filter(Boolean)
      );

      this.querySelectorAll("input, select, textarea").forEach((field) => {
        if (!field.name || field.type === "hidden") {
          return;
        }

        if (invalidNames.has(field.name)) {
          field.setAttribute("aria-invalid", "true");
        } else {
          field.removeAttribute("aria-invalid");
        }
      });
    }
  };
}

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
