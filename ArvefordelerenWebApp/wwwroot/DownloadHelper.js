window.downloadFile = (fileName, contentType, base64) => {
    console.log("DownloadHelper loaded and downloadFile invoked")
    const link = document.createElement("a");
    link.download = fileName;
    link.href = `data:${contentType};base64,${base64}`; 
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};
