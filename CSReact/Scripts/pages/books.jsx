var BookList = React.createClass({
    render: function() {
        var bookNodes = this.props.data.map(function (book) {
            return (
                <div>
                    {book.title} ({book.author})
                </div>
            );
        });

        return (
            <div className="bookList">
                {bookNodes}
            </div>
        );
    }
});

var App = React.createClass({
    getInitialState: function() {
        return {data: []};
    },

    componentDidMount: function() {
        $.get(this.props.url, function(result) {
            var book = result[0];
            if (this.isMounted()) {
            }
        }.bind(this));
    },

    componentWillMount: function() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function() {
            var jdata = JSON.parse(xhr.responseText);
            this.setState({ data: jdata });
        }.bind(this);
        xhr.send();
    },

    render: function() {
        return (
          <div className="commentBox">
            <BookList data={this.state.data} />
          </div>
      )
    }
});

ReactDOM.render(
  <App url="/api/books/Get" />,
  document.getElementById('content')
);