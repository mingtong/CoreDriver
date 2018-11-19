//var axios = require('axios');

var vList = new Vue({
    el: "#vList",
    data: {
        items: []
    },
    mounted() {

    },
});

axios.get('api/Video')
    .then(function (response) {
        // handle success
        if (response.status == 200) {
            response.data.forEach(element => {
                vList.$data.items.push(eval('(' + element + ')'));
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