# Resource Master

## Deployment

### Environment

The cluster can be managed from [Init Lab](https://pm4.init-lab.ch/).
The API is internet facing and the cluster can therefore be managed from your
local computer.

To get the kube config login, select the pm4-cluster, go to the namespaces menu
item, choose your namespace and then copy/download in the top right of the
page.

Handy tools for managing the cluster and fiddling with our resources are:
- kubectl
- helm
- k9s

### Migrate

```bash
cd ResourceMaster.DAL
dotnet ef migrations add <NameOfTheMigration>
```

### Resources

The `deploy` directory is the chart for `stage` and `prod` environment with
according values files for each.

Helm is only used as a templating engine in this case.
Until GitOps is put in place deploy manually with either helm or render the
templates and then deploy with kubectl.

```bash
# for example render the stage tempates with db.password BLA
# the namespace should be set everywhere, but still be careful what was set
helm template -f values-stage.yaml --set db.password=BLA . | k apply -f -
```

### Logging

There is loki and grafana for logging in our cluster. Grafana is not exposed
to the internet but can be portforwarded from the cluster.

```bash
kubectl port-forward logging-depl-xxxx 3000:3000 -n resourcemaster-stage
```

**Setup Datasource**

In `settings`, `datasources` choose loki and configure `http://logging-svc:3100`.

**Basic Querying**

Trigger an example query with e.g.

```bash
curl -X POST -H "Content-Type: application/json" http://logging-svc:3100/loki/api/v1/push --data-binary '{"streams": [{ "stream": { "foo": "bar2" }, "values": [ [ "1679011221215820152", "fizzbuzz" ] ] }]}'
```

In this example the huge number is a timestamp (`date +%s%N`).

In the `explore` panel running a code query with `{foo="bar2"}` should now return
this stream.
