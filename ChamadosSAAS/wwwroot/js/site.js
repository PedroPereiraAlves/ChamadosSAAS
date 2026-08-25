document.addEventListener("DOMContentLoaded", () => {
  document.querySelectorAll("[data-password-toggle]").forEach((button) => {
    button.addEventListener("click", () => {
      const input = button.parentElement?.querySelector("input");
      if (!input) {
        return;
      }

      const hidden = input.type === "password";
      input.type = hidden ? "text" : "password";
      button.textContent = hidden ? "Ocultar" : "Mostrar";
      button.setAttribute("aria-label", hidden ? "Ocultar senha" : "Mostrar senha");
    });
  });
});
