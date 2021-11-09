(() => {
    String.prototype.ensureStart = function(str) {

        if (!this.includes(str)) {
            return str.concat(this);
        }

        return this.toString();
        // let result = "" + this;

        // if (!this.includes(str)) {
        //     result = str.concat(this);
        // }

        // return result;
    };
    String.prototype.ensureEnd = function(str) {

        if (!this.includes(str)) {
            return this.concat(str);
        }

        return this.toString();
    };

    String.prototype.isEmpty = function() {

        return this.length === 0;
    };

    String.prototype.truncate = function(n) {
        if (n < 4) {
            return '.'.repeat(n);
        } else if (n >= this.length) {
            return this.toString();
        } else if (n < this.length) {
            let lastSpace = this.substr(0, n - 2).lastIndexOf(' ');
            if (lastSpace !== -1) {
                return this.substr(0, lastSpace).concat('...');
            } else {
                return this.substr(0, n - 3).concat('...');
            }
        }
    };

    String.format = function(string, ...params) {
            return params
                .reduce((str, param, i) => {
                    return str.replace(`{${i}}`, param);
                }, string);
        }
        // console.log("some".ensureStart("test"));


    // let str = 'my string';
    // console.log(str);
    // str = str.ensureStart('my');
    // console.log(str);
    // str = str.ensureStart('hello ');
    // console.log(str);
    // str = str.truncate(16);
    // console.log(str);
    // str = str.truncate(14);
    // console.log(str);
    // str = str.truncate(8);
    // console.log(str);
    // str = str.truncate(4);
    // console.log(str);
    // str = str.truncate(2);
    // console.log(str);
    // str = String.format('The {0} {1} fox',
    //     'quick', 'brown');
    // console.log(str);
    // str = String.format('jumps {0} {1}',
    //     'dog');
    // console.log(str);

})();