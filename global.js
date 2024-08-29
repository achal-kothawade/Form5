window.previewImage = (inputElem, imgElem) => {
    const url = URL.createObjectURL(inputElem.files[0]);
    imgElem.addEventListener('load', () => URL.revokeObjectURL(url), { once: true });
    imgElem.src = url;
}


//previewImage :- Image before uploading to the server from the browser without using ajax

//revokeObjectURL:- static method release an existing object URL. browser will release object automatically document is unloaded