let btn = document.getElementById("btn");

btn.addEventListener("click", function(){
    fetch('https://localhost:5001/api/movie/getall')
  .then(response => response.json())
  .then(data => {console.log(data)
            let tBody = document.getElementById("tbody");
            for(let movie of data )
            {
               tBody.innerHTML+=`
                <tr>
                    <td>${movie.title}</td>
                    <td>${movie.year}</td>
                </tr>
               `
            }
    });
})