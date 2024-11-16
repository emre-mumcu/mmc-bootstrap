hljs.addPlugin({
    "after:highlightElement": ({ el, text }) => {

        const wrapper = el.parentElement;

        if (wrapper == null) { return; }

        wrapper.classList.add("position-relative");

        const copyButton = document.createElement("button");
        copyButton.classList.add(
            "position-absolute",
            "top-0",
            "end-0",
            "border-0",
            "m-2",
            "text-muted",
            "copy-button",
        );

        copyButton.innerHTML = `<span class="material-symbols-outlined">content_copy</span>`;

        copyButton.onclick = () => {
            navigator.clipboard.writeText(text);
        };

        wrapper.appendChild(copyButton);
    },
});