//var axios = require('axios');

var aList = new Vue({
    el: "#aList",
    data: {
        items: []
    },
    mounted() {

    },
});

axios.get('api/Actress')
    .then(function (response) {
        // handle success
        if (response.status == 200) {
            response.data.forEach(element => {
                aList.$data.items.push(eval('(' + element + ')'));
            });
        }
    })
    .catch(function (error) {
        // handle error
        console.log(error);
    })
    .then(function () {
        // always executed
    });