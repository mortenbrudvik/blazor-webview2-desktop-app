var interopFunctions = {};

interopFunctions.registerIndexComponent = (dotnetObj) => {
    interopFunctions.indexComponent = dotnetObj;
};

interopFunctions.setFilePath = (filePath) => {
    console.log("JavaScript setFilePath executed");

    interopFunctions.indexComponent.invokeMethodAsync('SetFilePath', filePath);
};

interopFunctions.setFilePathInWinWPF = (filePath) => {
    window.chrome.webview.postMessage(JSON.stringify({
        messageType: 'filePath',
        value: filePath
    }));
};