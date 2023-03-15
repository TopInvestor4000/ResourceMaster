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
