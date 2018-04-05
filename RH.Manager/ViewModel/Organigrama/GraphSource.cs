using RH.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace RH.Manager.ViewModel
{
    public class GraphSource : ObservableGraphSourceBase<OrgAreaDeTrabalhoViewModel, Link>
    {
        public void PopulateGraphSource(OrgAreaDeTrabalhoViewModel area)
        {
            this.AddNode(area);
            this.SubscribeForAreaEvents(area);
            foreach (OrgAreaDeTrabalhoViewModel subNode in area.Children)
            {
                Link link = new Link(area, subNode);
                this.PopulateGraphSource(subNode);
                this.AddLink(link);
            }
        }

        private void SubscribeForAreaEvents(OrgAreaDeTrabalhoViewModel area)
        {
            area.AreaOuFuncionarioSelecting += OnAreaOrMemberSelecting;
            area.DeleteAreaRequested += OnDeleteAreaRequested;
            area.AddSubAreaRequested += OnAddSubAreaRequested;
            area.IsExpandedChanged += OnAreaIsExpandedChanged;
        }

        private void OnAreaIsExpandedChanged(object sender, EventArgs e)
        {
            OrgAreaDeTrabalhoViewModel team = sender as OrgAreaDeTrabalhoViewModel;
            if (sender != null)
            {
                this.ToggleChildrenVisibility(team, team.IsExpanded);
            }
        }

        internal void ToggleChildrenVisibility(HierarchicalNodeViewModel node, bool isExpanded)
        {
            var visibility = isExpanded ? Visibility.Visible : Visibility.Collapsed;

            foreach (OrgAreaDeTrabalhoViewModel subNode in node.Children)
            {
                subNode.Visibility = visibility;
                subNode.IsSelected = false;

                if (subNode.IsExpanded)
                {
                    this.ToggleChildrenVisibility(subNode, isExpanded);
                }
            }
            this.InternalLinks.Where(link => link.Source == node).ToList()
                        .ForEach(link =>
                        {
                            link.Visibility = visibility;
                            link.IsSelected = false;
                        });
        }

        private void OnAddSubAreaRequested(object sender, EventArgs e)
        {
            var parentArea = sender as OrgAreaDeTrabalhoViewModel;
            var codigo = $"{parentArea.AreaDb.Codigo}{parentArea.Children.Count + 1:D2}";
            OrgAreaDeTrabalhoViewModel newArea = new OrgAreaDeTrabalhoViewModel()
            {
                AreaDb = ((NewAreaEventArgs)e).IsDireccao ? new Direccao() { Codigo = codigo, DireccaoSuperiorId = parentArea?.AreaDb.Id, Nome = "Nova Direcção", Siglas = "" } as AreaDeTrabalho :
                (parentArea.AreaDb is Direccao ? new Departamento { Codigo = codigo, DireccaoId = parentArea.AreaDb.Id, Nome = "Novo Departamento", Siglas = "" } as AreaDeTrabalho :
                new Seccao { Codigo = codigo, DepartamentoId = parentArea.AreaDb.Id, Nome = "Nova Secção", Siglas = "" }),
                AreMembersVisible = true
            };
            newArea.Path = parentArea == null ? newArea.Name : parentArea.Path + "|" + newArea.Name;
            this.SubscribeForAreaEvents(newArea);
            if (!parentArea.IsExpanded)
                parentArea.IsExpanded = true;

            this.AddNode(newArea);
            parentArea.Children.Add(newArea);
            Link link = new Link(parentArea, newArea);
            this.AddLink(link);
        }

        private void OnDeleteAreaRequested(object sender, System.EventArgs e)
        {
            var linkToDelete = this.InternalLinks.Where(x => x.Target == sender).FirstOrDefault();
            if (linkToDelete != null)
            {
                this.RemoveLink(linkToDelete);
            }
            this.RemoveItem(sender as OrgAreaDeTrabalhoViewModel);
        }

        private void OnAreaOrMemberSelecting(object sender, System.EventArgs e)
        {
            this.InternalItems.ToList().ForEach(team => team.IsSelected = false);
            foreach (var item in this.InternalItems)
            {
                item.Funcionarios.ToList().ForEach(member => member.IsSelected = false);
            }
        }
    }
}
