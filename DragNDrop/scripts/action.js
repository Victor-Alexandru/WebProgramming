window.onload = () => {
  console.log("it is fully loaded");
  var classname = document.getElementsByClassName("photo");

  let firstPhoto = "";
  let secondPhoto = "";
  let click = 0;

  var verif = function () {
    let imgs = document.getElementsByTagName("img");
    flag = 1;
    let pString ="";
    for (let img of imgs) {
      pString += img.getAttribute("id")[0] + "";

    }
    return pString === "123456789";
  }

  var swap = function () {


    firstPhoto = firstPhoto ? firstPhoto : this.getAttribute("id");

    click++; //a flag that will help us with managing the other flags

    secondPhoto = (click >= 2 && firstPhoto) ? this.getAttribute("id") : secondPhoto;

    document.getElementById("firstPhoto").innerText = (firstPhoto) ? document.getElementById(firstPhoto).getElementsByTagName("img")[0].getAttribute("id") : "";
    document.getElementById("secondPhoto").innerText = (secondPhoto) ? document.getElementById(secondPhoto).getElementsByTagName("img")[0].getAttribute("id") : "";


    if (secondPhoto && firstPhoto) {


      if (firstPhoto != secondPhoto) {
        let firstTD = document.getElementById(firstPhoto);
        let secondTD = document.getElementById(secondPhoto);

        let x = firstTD.childNodes[0];
        let y = secondTD.childNodes[0];

        firstTD.removeChild(firstTD.childNodes[0]);
        secondTD.removeChild(secondTD.childNodes[0]);

        firstTD.appendChild(y);
        secondTD.appendChild(x);
      }

      // resseting the flags
      click = 0;
      firstPhoto = "";
      secondPhoto = "";

      document.getElementById("finish").innerText = verif() ? "Congratiulantions : Hagi is Complete" : "";


    }



  };

  for (let i = 0; i < classname.length; i++) {
    classname[i].addEventListener('click', swap);
  }

}