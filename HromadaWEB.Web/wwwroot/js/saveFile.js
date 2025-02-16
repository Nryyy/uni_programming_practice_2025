function saveAsFile(filename, byteArray) {
    if (!byteArray || byteArray.length === 0) {
        console.error("Invalid byte array.");
        return;
    }

    var blob = new Blob([byteArray], { type: "application/pdf" });
    var link = document.createElement("a");
    link.href = window.URL.createObjectURL(blob);
    link.download = filename;
    link.click();

    // Вивільнення ресурсу після завантаження
    window.URL.revokeObjectURL(link.href);
}
